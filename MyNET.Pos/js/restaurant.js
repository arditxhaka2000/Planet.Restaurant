let tableId = 0;
let selectableDivs = [];
let bashkocount = 0;

function receiveSpaces(jsonData) {

    var data = JSON.parse(jsonData);
    var container = document.getElementById('floors-div');
    var html = "";
    data.forEach(function (element) {
        html += "<button type='button' class='space-button btn btn-secondary'  id= '" + element.Id + "'> " + element.Name + " </button>";

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

    console.log(data);
    data.forEach(function (element) {
        var left = (element.LocationX * screen.width) / 100;
        var top = (element.LocationY * screen.height) / 100;
        var pic = "Table";
        var forecolor = "black";
        if (element.inPos === 1) {
            backcolor = "#682825";
            var forecolor = "white";
            pic = "Table1";
        }
        html += "<div class='draggable' id= d" + element.Id + " onclick ='sendPOS(" + element.Id + ")' style='left: " + left + "px; top: " + top + "px; user-select: none; background-image:url(Resources/" + pic + ".png);'>";
        html += "<div class='check-icon'></div>";
        html += "<br>"
        html += "<div class='row'>";
        if (element.Name.length > 10) {
            html += "<h5 class='name' style='color:" + forecolor + "; max-width: 70px; word-wrap: break-word;'>" + element.Name + "</h5>";
        } else {
            html += "<h5 class='name' style='color:" + forecolor + "'>" + element.Name + "</h5>";
        }
        html += "</div>"
        html += "<br>"
        html += "<div class='row'>";
        html += "<h5  style = 'color:" + forecolor + "'>" + element.inPosTotal + "</h5>";
        html += "</div>"
        html += "</div>"

    });

    container.innerHTML = html;
}
function openPos() {

    return tableId;
}
function sendPOS(id) {
    tableId = id;
    if (optionValue === 'Bashko') {

        var parentDiv = document.getElementById("d" + id);

        if (parentDiv) {

            var checkIcon = parentDiv.querySelector('.check-icon');
            console.log('1', bashkocount);
            if (checkIcon && bashkocount < 2) {
                if (checkIcon.style.display === 'block') {

                    checkIcon.style.display = 'none';

                    const index = selectableDivs.indexOf(id);
                    if (index > -1) {
                        selectableDivs.splice(index, 1);
                    }
                    bashkocount--;

                }
                else {
                    selectableDivs.push(id);
                    checkIcon.style.display = 'block';
                    bashkocount++;
                    console.log('2', bashkocount);

                }

            }
            else {
                if (checkIcon.style.display === 'block') {

                    checkIcon.style.display = 'none';

                    const index = selectableDivs.indexOf(id);
                    if (index > -1) {
                        selectableDivs.splice(index, 1);
                    }
                    bashkocount--;
                    console.log('3', bashkocount);

                }
            }
        }
    }
    else if (optionValue === 'Transfero') {
        var parentDiv = document.getElementById("d" + id);

        if (parentDiv) {

            var checkIcon = parentDiv.querySelector('.check-icon');
            console.log('1', bashkocount);
            if (checkIcon && bashkocount < 2) {
                if (checkIcon.style.display === 'block') {

                    checkIcon.style.display = 'none';

                    const index = selectableDivs.indexOf(id);
                    if (index > -1) {
                        selectableDivs.splice(index, 1);
                    }
                    bashkocount--;

                }
                else {
                    selectableDivs.push(id);
                    checkIcon.style.display = 'block';
                    bashkocount++;
                    console.log('2', bashkocount);

                }

            }
            else {
                if (checkIcon.style.display === 'block') {

                    checkIcon.style.display = 'none';

                    const index = selectableDivs.indexOf(id);
                    if (index > -1) {
                        selectableDivs.splice(index, 1);
                    }
                    bashkocount--;
                    console.log('3', bashkocount);

                }
            }
        }
    }
    else {
        window.chrome.webview.postMessage("POS");

    }

}
function sendBashko() {
    return selectableDivs;
}
function sendSpaceId(value) {
    // Example data to send
    var data = value;
    window.chrome.webview.postMessage(data);
}
var optionValue = '';
function functionOptionsRestaurant(m) {
    optionValue = m;
    if (optionValue === 'Lokacioni') {
        var draggableElements = document.querySelectorAll('.draggable');
        draggableElements.onclick = null;


        draggableElements.forEach(function (element) {
            element.addEventListener('mousedown', startDragging);
            element.setAttribute('data-click-event', element.getAttribute('onclick'));
            element.removeAttribute('onclick');
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
    if (optionValue === 'Bashko') {
        //toggleCheckIcons();
    }
}
function getDivLocations() {
    var divs = document.querySelectorAll('.draggable');
    var locations = [];

    divs.forEach(function (div) {
        var rect = div.getBoundingClientRect();
        var location = {
            id: div.id,
            LocationX: rect.left.toString(),
            LocationY: rect.top.toString()
        };
        locations.push(location);

    });

    return locations;
}
function changeTheme(v) {

    var divs = document.querySelectorAll('body');
    divs.forEach(function (div) {
        if (v === 'dark') {
            div.style.backgroundColor = '#313237';

        }
        else {
            div.style.backgroundColor = 'white';

        }
    });
}

function toggleSelection(event) {

    const divId = event.target.id;
    const targetDiv = document.getElementById(divId);
    if (targetDiv) {
        var a = container.classList.toggle('show-check');


    }
    selectableDivs.push(divId);
    console.log(selectableDivs);
}
function toggleCheckIcons() {
    var parentElement = document.querySelector('.container-fluid');

    // Add the 'show-check' class to the parent element
    parentElement.classList.add('show-check');
}