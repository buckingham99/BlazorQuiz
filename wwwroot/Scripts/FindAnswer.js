

window.FindElement = function (answerId, value) {
    var el = document.getElementById(answerId);
    /*debugger;*/
    el.innerText = "";
    el.innerText = value;
    console.log("Answer: " + answerId + " Value: " + value);
    return value;
    
}