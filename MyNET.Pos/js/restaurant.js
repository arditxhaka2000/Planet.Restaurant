function receiveSpaces(jsonData) {

    var data = JSON.parse(jsonData);
    var container = document.getElementById('floors-div');
    var html = "";
    data.forEach(function (element) {
        html += "<button type='button' id= '" + element.Id + "' class='space-button btn btn-info' style='margin-right: 10px;'> " + element.Name + " </button>";

    });
    container.innerHTML = html;
    var spaceButtons = document.querySelectorAll('.space-button');

    spaceButtons.forEach(function (button) {
        button.addEventListener('click', function (event) {
            var buttonId = event.target.id;
            sendSpaceId(buttonId);
            //loadTablesForSpace(spaceId);
        });
    });
}
function receiveTables(jsonData) {

    var data = JSON.parse(jsonData);


    var container = document.getElementById('table_div');
    var html = "";


    data.forEach(function (element) {
        var left = (element.LocationX * 1920) / 100;
        var top = (element.LocationY * 1920) / 100;
        var backcolor = "white";
        var forecolor = "black";
        if (element.inPos === 1) {
            backcolor = "red";
            var forecolor = "white";

        }
        html += "<div class='draggable' id='table' style='left: " + left + "px; top: " + top + "px; background-color:" + backcolor + "; user-select: none;'>";
        html += "<br>"
        html += "<div class='row'>";
        html += "<h5 class='name' style = 'color:" + forecolor + "'>" + element.Name + "</h5>";
        html += "</div>"
        html += "<br>"
        html += "<div class='row'>";
        html += "<h5  style = 'color:" + forecolor + "'>" + element.LocationX + "</h5>";
        html += "</div>"
        html += "</div>"

    });

    container.innerHTML = html;
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
function sendTableLocation(value) {
    var data = value;
    const customEvent = new CustomEvent('myCustomEvent', { detail: data });
    document.dispatchEvent(customEvent);

}
function functionOptionsRestaurant(m) {
    var optionValue = m;
    if (optionValue === 'Lokacioni') {
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
    else if (optionValue = 'Ruaj') {
        getDivLocations();

    }
}
function getDivLocations() {
    var divs = document.querySelectorAll('.draggable');
    var locations = [];

    divs.forEach(function (div) {
        var rect = div.getBoundingClientRect();
        var location = {
            id: div.id,
            top: rect.top,
            left: rect.left
        };
        locations.push(location);
    });
    sendTableLocation(locations);
}
