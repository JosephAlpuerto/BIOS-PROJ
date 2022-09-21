document.getElementById('Button1').addEventListener("click", function () {
    this.classList.add("loading");
    this.innerHTML = "<span class='icon'>&#8635; </span>Waiting...";
});