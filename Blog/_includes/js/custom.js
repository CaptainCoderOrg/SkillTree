// Key for Theme Setting
const storageThemeKey = "selectedTheme";
function setTheme(theme) {
    let toggleDarkMode = document.querySelector('.js-toggle-dark-mode');
    if (theme === 'dark') {
        jtd.setTheme('dark');
        toggleDarkMode.classList.add("dark");
        toggleDarkMode.classList.remove("light");
    } else {
        jtd.setTheme('light');
        toggleDarkMode.classList.add("light");
        toggleDarkMode.classList.remove("dark");
    }
};

// Override standard jtd.getTheme function, to have right selector
window.jtd.getTheme = function() {
    var cssFileHref = document.querySelector('[rel="stylesheet"][title="theme"]').getAttribute('href');
    return cssFileHref.substring(cssFileHref.lastIndexOf('-') + 1, cssFileHref.length - 4);
}

// Override standard jtd.setTheme function, to store changed theme in local storage
window.jtd.setTheme = function(theme) {
  localStorage.setItem(storageThemeKey, theme);
  var cssFile = document.querySelector('[rel="stylesheet"][title="theme"]');
  cssFile.setAttribute('href', '{{ "assets/css/just-the-docs-" | relative_url }}' + theme + '.css');
}

// Apply click listener to toggle button
document.addEventListener("DOMContentLoaded", function(event) { 
    jtd.addEvent(document.querySelector('.js-toggle-dark-mode'), 'click', function(){
        if (jtd.getTheme() === 'dark') {
            setTheme('light');
        } else {
            setTheme('dark');
        }
    });
});

// Apply listener to system theme change
window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', event => {
    const newColorScheme = event.matches ? "dark" : "light";
    setTheme(newColorScheme);
});


// This applies the theme from local storage, if it exists
if (localStorage.getItem(storageThemeKey)) {
    window.jtd.setTheme(localStorage.getItem(storageThemeKey));
} else {
    // first time visitors - apply system default
    const theme = window.matchMedia('(prefers-color-scheme: dark)').matches ? "dark" : "light";
    window.jtd.setTheme(theme);
}
