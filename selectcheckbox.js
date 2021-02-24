function GetData() {

    var values = new Array();


    $.each($("input[name='chkBox[]']:checked"), function () {
        var data = $(this).parents('tr:eq(0)');
        var obj = {
            'MobileNo': $(data).find('td:eq(1)').text(),
            'Message': $(data).find('td:eq(2)').text(),
            'EntryBy': $(data).find('td:eq(3)').text(),
            'Entrydate': $(data).find('td:eq(4)').text(),
            'status': $(data).find('td:eq(5)').text(),
            'status_date': $(data).find('td:eq(6)').text()
        };

        values.push(obj);
    });

    values = JSON.stringify({ 'values': values });

    $.ajax({

        type: "POST",
        url: '/Home/selectddata',
       // url: '/Admin/Approval_UsersData',
        contentType: "application/json;",
        data: values


    });
}




