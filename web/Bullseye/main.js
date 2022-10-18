let addOrUpdate;

window.onload = function () {
  document.querySelector("#GetButton").addEventListener("click", getAllItems);
  document.querySelector("table").addEventListener("click", handleRowClick);

  loadLocations();
  loadCategories();
};

function handleRowClick(e) {
  clearSelections();
  if ((e.target.parentElement.tagName == "TD")) {
    e.target.parentElement.parentElement.classList.add("highlighted");
  } else {
    e.target.parentElement.classList.add("highlighted");
  }
}

function getAllItems() {
  //let url = "api/getAllItems.php";

  let location = document.querySelector("#locationSelect").value;
  let category = document.querySelector("#categoriesSelect").value;
  url = "StoreTableAPI/items/STJN";

  if (location !== "" && location !== "") {
    url = "StoreTableAPI/items/" + location + "/" + category;
  }
  let xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      let resp = xmlhttp.responseText;
      if (resp.search("ERROR") >= 0) {
        alert("oh no...");
      } else {
        buildTable(xmlhttp.responseText);
        clearSelections();
      }
    }
  };
  xmlhttp.open("GET", url, true);
  xmlhttp.send();
}

function buildTable(text) {
  let arr = JSON.parse(text);
  let theTable = document.querySelector("table");
  let html = theTable.querySelector("tr").innerHTML;
  for (let i = 0; i < arr.length; i++) {
    let row = arr[i];
    html += "<tr>";

    html += "<td><input type='text' name='itemID' value ='"+row.itemID+"' hidden>" + row.itemID + "</td>";
    html += "<td>" + row.itemName + "</td>";
    html += "<td>" + row.itemCategory + "</td>";
    html += "<td>" + row.locationID + "</td>";
    html += "<td>" + row.inStock + "</td>";
    html +=
      "<td><input type='number' name='quantity' min='0' max='" +
      row.inStock +
      "' value = " +
      row.quantity +
      "></td>";

    html += "</tr>";
  }
  theTable.innerHTML = html;
}

function clearSelections() {
  let trs = document.querySelectorAll("tr");
  for (let i = 0; i < trs.length; i++) {
    trs[i].classList.remove("highlighted");
  }
}

function loadLocations() {
  var url = "StoreTableAPI/items/locations";
  var xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      var resp = xmlhttp.responseText;
      if (resp.search("ERROR") >= 0) {
        alert("oh no...");
        console.log(resp);
      } else {
        console.log(resp);

        initLocationBox(resp);
      }
    }
  };
  xmlhttp.open("GET", url, true);
  xmlhttp.send();
}

function loadCategories() {
  var url = "StoreTableAPI/items/categories";
  var xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      var resp = xmlhttp.responseText;
      if (resp.search("ERROR") >= 0) {
        alert("oh no...");
        console.log(resp);
      } else {
        console.log(resp);

        initCategoriesBox(resp);
      }
    }
  };
  xmlhttp.open("GET", url, true);
  xmlhttp.send();
}

function initLocationBox(text) {
  var theText = JSON.parse(text);
  var html = "";
  for (var i = 0; i < theText.length; i++) {
    var locationID = theText[i];
    html += "<option value='" + locationID + "'>" + locationID + "</option>";
  }
  document.querySelector("#locationSelect").innerHTML = html;
}

function initCategoriesBox(text) {
  var theText = JSON.parse(text);
  var html = "";
  for (var i = 0; i < theText.length; i++) {
    var itemCategory = theText[i];
    html +=
      "<option value='" + itemCategory + "'>" + itemCategory + "</option>";
  }
  document.querySelector("#categoriesSelect").innerHTML = html;
}