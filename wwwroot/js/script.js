function send1(){
    alert("hey there! you triggered an alert!");
}
function send2(){
    document.getElementById("results").innerText = "you triggered action 2!";
}
async function send3(){
    var input = prompt("Please custom argument object", '{"arg1": "string", "arg2": "string"}');
    const response = await fetch('/YourCustom', {
        method: 'POST',
        body: input, // string or object
        headers: {
        'Content-Type': 'application/json'
        }
    });
    var myjson = await response.json(); 
    document.getElementById("results").innerText = JSON.stringify(myjson);
}
function swagger(){
    window.location.href = '/swagger'
}