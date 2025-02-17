const sidebarToggle = document.querySelector("#sidebar-toggle");
const sidebar = document.querySelector("#sidebar");

sidebarToggle.addEventListener("click", function () {
    console.log("Toggle button clicked");
    sidebar.classList.toggle("collapsed");
});
