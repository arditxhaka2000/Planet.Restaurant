function sendData() {
    // Example data to send
    var data = "Hello from HTML!";
    window.chrome.webview.postMessage(data);
}

function receiveDataFromCSharp(jsonData) {
    console.log(jsonData);

    var data = JSON.parse(jsonData);

    console.log(data);

    var container = document.getElementById('table_div');
    var html = "";


    data.forEach(function (element) {
        console.log(element);

        html += "<h5 class='name'>" + element.Name + "</h5>";
        html += "<h5>" + element.LocationX + "</h5>";
      
    });

    container.innerHTML = html;
}