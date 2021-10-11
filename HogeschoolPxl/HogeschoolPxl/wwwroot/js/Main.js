//handel active class
window.onload = function () {
    var title = document.title.split('-')[0].trim(' ');
    let links = document.querySelectorAll('header nav div ul li a');
    links.forEach(a => {
        if (a.getAttribute('data-link') === title) {
            a.classList.add('active');
        }
    });
};