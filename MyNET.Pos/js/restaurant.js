function receiveDataFromCSharp(jsonData) {
    console.log(jsonData);

    var data = JSON.parse(jsonData);

    console.log(data);

    var container = document.getElementById('table_div');
    var html = "";


    data.forEach(function (element) {
        console.log(element);
        html += "<div class='col' style='position: absolute; left: " + element.LocationX + "px; top: " + element.LocationY + "px;'>"
        html += "<h5 class='name'>" + element.Name + "</h5>";
        html += "<h5>" + element.LocationX + "</h5>";
        html += "</div>"

    });

    container.innerHTML = html;
}
function sendData() {
    // Example data to send
    var data = "Hello from HTMLA!";
    window.chrome.webview.postMessage(data);
}

s