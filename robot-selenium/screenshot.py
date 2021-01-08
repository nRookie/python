DEFAULT_FILENAME_PAGE = "selenium-screenshot-{index}.png"
DEFAULT_FILENAME_ELEMENT = "selenium-element-screenshot-{index}.png"

def _get_screenshot_path(self, filename):
    if self._screenshot_root_directory != EMBED:
        directory = self._screenshot_root_directory or self.log_dir
    else:
        directory = self.log_dir
    filename = filename.replace("/", os.sep)
    index = 0
    while True:
        index += 1
        formatted = _format_path(filename, index)
        path = os.path.join(directory, formatted)
        # filename didn't contain {index} or unique path was found
        if formatted == filename or not os.path.exists(path):
            return path