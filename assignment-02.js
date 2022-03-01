var buttons = document.querySelectorAll(".buttons button");
var ghost = document.getElementsByClassName("ghost")[0];
for(i = 0; i < buttons.length; i++)
{
    buttons[i].addEventListener("click",GhostClasses);

}
function GhostClasses()
{
    if(this.getAttribute("data-add"))
    {
    ghost.classList.add(this.getAttribute("data-add"));
    }
    if(this.getAttribute("data-remove"))
    {
    ghost.classList.remove(this.getAttribute("data-remove"));
    }
}