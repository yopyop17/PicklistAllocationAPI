function showLoading() {
    $('#overlay').show();
}
function hideLoading() {
    $('#overlay').fadeOut();
}

const body = document.querySelector('body'),
    sidebar = body.querySelector('nav'),
    toggle = body.querySelector(".toggle"),
    //searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    abbrevation = document.querySelector(".abbr");
modeText = body.querySelector(".mode-text");
const removeSelectors = (sel) => document.querySelectorAll(sel).forEach(el => el.remove());

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
    //removeSelectors(".abbr");  
})
//searchBtn.addEventListener("click", () => {
//    sidebar.classList.remove("close");

//})








