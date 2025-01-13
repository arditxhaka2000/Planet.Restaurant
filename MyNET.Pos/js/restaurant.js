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

    data.forEach(function (element) {
        var left = (element.LocationX * screen.width) / 100;
        var top = (element.LocationY * screen.height) / 100;
        var tWidth = element.Width; 
        var tHeight = element.Height; 
        console.log(tWidth, tHeight);
        var pic = "Table";
        var forecolor = "black";
        var backcolor = "#618368";
        if (element.inPos === 1) {

            backcolor = "#682825";
            var forecolor = "white";
            pic = "Table1";
        }

        if (element.Shape === "Katrore") {

            html += "<div class='draggable' data-tableId= " + element.Id + " onclick ='sendPOS(" + element.Id + ")' style='left: " + left + "px; top: " + top + "px; width: " + tWidth + "px; height: "+tHeight+"px; user-select: none; background:" + backcolor + ";'>";

        }
        else if (element.Shape === "Rreth") {
            html += "<div class='draggable' data-tableId= " + element.Id + " onclick ='sendPOS(" + element.Id + ")' style='left: " + left + "px; top: " + top + "px; width: " + tWidth + "px; height: " + tHeight +"px; user-select: none; background:" + backcolor + ";border-radius: 50%;'>";

        }
        else {

            html += "<div class='draggable' data-tableId= " + element.Id + " onclick ='sendPOS(" + element.Id + ")' style='left: " + left + "px; top: " + top + "px; width: " + tWidth + "px; height: " + tHeight +"px ;user-select: none; background-image:url(Resources/" + pic + ".png);'>";

        }

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
        html += "<h5 class='total' style = 'color:" + forecolor + "'>" + element.inPosTotal + "</h5>";
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
    if (optionValue === 'Transfero') {

        var parentDiv = document.querySelector("[data-tableId='" + tableId + "']");

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
    else if (optionValue === 'Bashko') {

        var parentDiv = document.querySelector("[data-tableId='" + tableId + "']");


        if (parentDiv) {

            var checkIcon = parentDiv.querySelector('.check-icon');

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
    console.log('sadasd', selectableDivs);
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

            // Find the associated check-icon div
            var checkIcon = draggable.querySelector('.check-icon');

            // Ensure the check-icon is initially hidden
            if (checkIcon) {
                checkIcon.style.display = 'none';
            }

            document.addEventListener('mousemove', dragDiv);

            function dragDiv(e) {
                if (isDragging) {
                    draggable.style.left = e.clientX - offsetX + 'px';
                    draggable.style.top = e.clientY - offsetY + 'px';

                    // Display the check-icon when moving
                    if (checkIcon) {
                        checkIcon.style.display = 'block';
                    }
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
function changeTableColor(tableId, color) {
    const tableElement = document.querySelector("[data-tableId='" + tableId + "']");
    console.log('ktu12', color);
    if (tableElement) {
        const h5 = tableElement.getElementsByTagName('h5');

        if (color === 'red') {
            tableElement.style.backgroundImage = "url('Resources/Table1.png')";
            for (let i = 0; i < h5.length; i++) {
                h5[i].style.color = 'white';
            }

        }
        else {
            tableElement.style.backgroundImage = "url('Resources/Table.png')";
            for (let i = 0; i < h5.length; i++) {
                h5[i].style.color = 'black';
            }
        }

    }
}
function changeTableTotal(tableId, total) {
    const tableElement = document.querySelector("[data-tableId='" + tableId + "']");
    if (tableElement) {
        const h5Total = tableElement.querySelector('h5.total');
        console.log('ktu2', h5Total);

        if (h5Total) {
            h5Total.textContent = total;
            console.log('ktu22', total);

        }

    }
}
function getDivLocations() {
    var divs = document.querySelectorAll('.draggable');
    var locations = [];

    divs.forEach(function (div) {
        var rect = div.getBoundingClientRect();
        var location = {
            id: div.getAttribute('data-tableId'),
            LocationX: rect.left.toString(),
            LocationY: rect.top.toString()
        };
        locations.push(location);
        console.log(locations);

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