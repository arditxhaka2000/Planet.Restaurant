function receiveSpaces(jsonData) {

    var data = JSON.parse(jsonData);
    console.log(data);
    var container = document.getElementById('floors-div');
    var html = "";
    data.forEach(function (element) {
        html += "<button type='button' id= '" + element.Id + "' class='space-button btn btn-info' style='margin-right: 10px;'> " +element.Name+ " </button>";

    });
    container.innerHTML = html;
    var spaceButtons = document.querySelectorAll('.space-button');

    spaceButtons.forEach(function (button) {
        button.addEventListener('click', function (event) {
            var buttonId = event.target.id;
            console.log('spaceid', buttonId);
            sendSpaceId(buttonId);
            //loadTablesForSpace(spaceId);
        });
    });
}
function receiveTables(jsonData) {

    var data = JSON.parse(jsonData);

    console.log(data);

    var container = document.getElementById('table_div');
    var html = "";


    data.forEach(function (element) {
        var left = (element.LocationX * 1920) / 100; 
        var top = (element.LocationY * 1920) / 100;
        html += "<div class='draggable' id='draggable' style='left: " + left + "px; top: " + top + "px;'>";
        html +="<br>"
        html += "<div class='row'>";
        html += "<h5 class='name'>" + element.Name + "</h5>";
        html += "</div>"
        html += "<br>"
        html += "<div class='row'>";
        html += "<h5>" + element.LocationX + "</h5>";
        html += "</div>"
        html += "</div>"

    });

    container.innerHTML = html;
    var draggableElements = document.querySelectorAll('.draggable');
    draggableElements.forEach(function (element) {
        element.addEventListener('mousedown', startDragging);
    });

    function startDragging(e) {

        e.stopPropagation();

        var draggable = e.target;
        var offsetX = e.clientX - draggable.getBoundingClientRect().left;
        var offsetY = e.clientY - draggable.getBoundingClientRect().top;
        var isDragging = true;

        document.addEventListener('mousemove', dragDiv);

        function dragDiv(e) {
            if (isDragging) {
                draggable.style.left = e.clientX - offsetX + 'px';
                draggable.style.top = e.clientY - offsetY + 'px';
            }
        }

        document.addEventListener('mouseup', function () {
            isDragging = false;
            document.removeEventListener('mousemove', dragDiv);
        });
    }
}
function sendData() {
    // Example data to send
    var data = "Hello from HTMLA!";
    window.chrome.webview.postMessage(data);
}
function sendSpaceId(value) {
    // Example data to send
    var data = value;
    window.chrome.webview.postMessage(data);
}

