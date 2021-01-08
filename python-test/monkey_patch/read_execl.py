# Reading an excel file using Python
import xlrd
import os
# Give the location of the file

# get file list from xls file

# filename_column should be your filename column in excel file
def get_file_list_from_xls(path, file_name_column=0):
    loc = (path)
    
    # To open Workbook
    wb = xlrd.open_workbook(loc)
    sheet = wb.sheet_by_index(0)

    # For row  and column 0
    # column 0 is file name

    res = []
    for i in range(sheet.nrows):
        res.append(sheet.cell_value(i, file_name_column))

    return res
def get_file_list_from_path(path):
    return os.listdir(path)

def get_diff_between_directory_and_xlsx(excel_path, filename_row, directory):
    excel_list = get_file_list_from_xls(excel_path, filename_row)
    file_list = get_file_list_from_path(directory)

    print("-------------diff excel to directory---------")
    diff = set(excel_list) - set(file_list)
    for file in diff:
        print(file)

    print("------------ diff directory to excel --------")
    diff = set(file_list) - set(excel_list)
    for file in diff:
        print(file)

if __name__ == "__main__":
    get_diff_between_directory_and_xlsx('logi.xls', 0, '.')