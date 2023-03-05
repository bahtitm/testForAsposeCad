
$(function() {
  const URL = 'https://localhost:7107/api';

  const postsStore = new DevExpress.data.CustomStore({
    key: 'id',
    load() {
      return sendRequest(`${URL}/Post`,'GET');
    },
    insert(values) {        
      return sendRequest(`${URL}/Post`, 'POST', {
        values: JSON.stringify(values),
      });
    },
    update(key, values) {
      return sendRequest(`${URL}/Post/${key}`, 'PUT', {
        values: JSON.stringify(values),
      });
    },
    remove(key) {
      return sendRequest(`${URL}/Post/${key}`, 'DELETE');
    },
  });
    const dataGrid = $("#dataGrid").dxDataGrid({
        dataSource: postsStore,
        allowColumnResizing: true,
        columnAutoWidth: true,
        columnFixing: {
            enabled: true
        },
        allowColumnReordering: true,
        columnChooser: { enabled: true },
        columns: [{
            dataField: "name",
            validationRules: [{
                type: "required"
            }],
            fixed: true
        }, {
            dataField: "description",
            validationRules: [{
                type: "required"
            }]
        }, 
        ],
        filterRow: { visible: true },
        searchPanel: { visible: true },
        groupPanel: { visible: true },
        selection: { mode: "single" },
        onSelectionChanged: function(e) {
            e.component.byKey(e.currentSelectedRowKeys[0]).done(employee => {
                if(employee) {
                    $("#selected-employee").text(`Selected employee: ${employee.FullName}`);
                }
            });
        },
        summary: {
            groupItems: [{
                summaryType: "count"
            }]
        },
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        },
        toolbar: {
            items: [
                "groupPanel",
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        text: "Collapse All",
                        width: 136,
                        onClick(e) {
                            const expanding = e.component.option("text") === "Expand All";
                            dataGrid.option("grouping.autoExpandAll", expanding);
                            e.component.option("text", expanding ? "Collapse All" : "Expand All");
                        },
                    },
                },
                {
                    name: "addRowButton",
                    showText: "always"
                },
                "exportButton",
                "columnChooserButton",
                "searchPanel"
            ]
        },
        masterDetail: {
            enabled: true,
            template: function (_, options) {
                const employee = options.data;
                const photo = $("<img>")
                    .addClass("employee-photo")
                    .attr("src", employee.Photo);
                const notes = $("<p>")
                    .addClass("employee-notes")
                    .text(employee.Notes);
                return $("<div>").append(photo, notes);
            }
        },
        export: {
            enabled: true,
            formats: ['xlsx', 'pdf']
        },
        onExporting(e) {
            if (e.format === 'xlsx') {
                const workbook = new ExcelJS.Workbook(); 
                const worksheet = workbook.addWorksheet("Main sheet"); 
                DevExpress.excelExporter.exportDataGrid({ 
                    worksheet: worksheet, 
                    component: e.component,
                }).then(function() {
                    workbook.xlsx.writeBuffer().then(function(buffer) { 
                        saveAs(new Blob([buffer], { type: "application/octet-stream" }), "DataGrid.xlsx"); 
                    }); 
                }); 
                e.cancel = true;
            } 
            else if (e.format === 'pdf') {
                const doc = new jsPDF();
                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: doc,
                    component: e.component,
                }).then(() => {
                    doc.save('DataGrid.pdf');
                });
            }
        }
    }).dxDataGrid("instance");


function sendRequest(url, method , data) {
    const d = $.Deferred();    
    if(method==='POST' )
    {
        let t=data.values;
        data=t;
        
    }
    if(method==='PUT' )
    {
        var t=data.values;
      
        data=t;
        console.log("data",data);
    }

    logRequest(method, url, data);
    $.ajax(url, {     
      method,
      data,
      cache: false,
      accept: "application/json",
      contentType: "application/json",      
      xhrFields: { withCredentials: true },
    }).done((result) => {        
      d.resolve(result);
    }).fail((xhr) => {
      d.reject(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
    });

    return d.promise();
  }

  function logRequest(method, url, data) {
    const args = Object.keys(data || {}).map((key) => `${key}=${data[key]}`).join(' ');

    const logList = $('#requests ul');
    const time = DevExpress.localization.formatDate(new Date(), 'HH:mm:ss');
    const newItem = $('<li>').text([time, method, url.slice(URL.length), args].join(' '));

    logList.prepend(newItem);
  }
});

