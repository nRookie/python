$(function() {
    console.log("whee!")

    // event handler
    $("#btn-click").click(function() {
        if ($('input').val() !== '') {
            var input = $("input").val()
            console.log(input)
            $('ol').append('<li><a href="">x</a>' + input + '</li>');
        }
        $('input').val('');
    })

});

$(document).on('click', 'a', function (event) {
    event.preventDefault();
    $(this).parent().remove();
    });

// 1. $("#btn-click").click(function() { is the event. This initiates the process, running
//     the code in the remainder of the function. In other words, the remaining JavaScript
//     will not run until there is a button click.
//     2. var input = $("input").val() sets a variable called input with the inputted value
//     from the form, which is grabbed via .val() .
//     3. id="btn-click" is used to tie the HTML to the JavaScript. This id is referenced in
//     the initial event within the JavaScript file - "#btn-click" .
//     4. console.log(input) displays the word to the end user via the JavaScript console.


// The $() in $("#btn-click").click() is a jQuery constructor. Basically,
// it's used to tell the browser that the code within the parenthesis is jQuery.