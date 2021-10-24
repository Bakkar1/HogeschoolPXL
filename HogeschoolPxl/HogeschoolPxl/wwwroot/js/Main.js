//handel active class
window.addEventListener('load', function () {
    var title = document.title.split('-')[0].trim(' ');
    let links = document.querySelectorAll('header nav div ul li a');
    links.forEach(a => {
        if (a.getAttribute('data-link').toLowerCase() === title.toLowerCase()) {
            a.classList.add('active');
        }
    });
},false);