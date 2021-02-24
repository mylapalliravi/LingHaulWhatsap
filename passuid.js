
var userid;
var approvedata = function (id) {

    // var url = "/Admin/CloseTrip?TripNo=" + id;
    userid = id;
    //    $("#myModalBodyDiv1").load(url, function () {
    //$("#myModal1").modal("show");

    //})
}

function getapprove() {
    var id = userid;
           // var id = $('#hdnid').val();
            var PaymentRefNo = $('#PaymentRefNo').val();
            var basepath = $('#basepath').val();
            var InstanceId = $('#InstanceId').val();
            var Token = $('#Token').val();
            var Remarks = $('#Remarks').val();

            $.ajax({

        type: "POST",
                //  url: '/Home/selectddata',
                url: '/Admin/Approval_UsersData',
                //    contentType: "application/json;",
                data: { "id": id, "PaymentRefNo": PaymentRefNo, "basepath": basepath, "InstanceId": InstanceId, "Token": Token, "Remarks": Remarks },
                success:
                    function () {

                        sweetAlert("Great!", "User Approved Succesfully...", "success")

                        setTimeout("window.location = 'Pending_Approvals'", 3000)

                        $('#successMessage').html("User Approved Successfully...");

                     //   sweetAlert("Here's the title!", "...and here's the text!");

                        //sweetAlert({
                            
                        //    title: "Good job!",
                        //    text: "User Approved Succesdfully...",
                        //    icon: "success",

                        //}).then(function () {
                        //    setTimeout("window.location = 'Pending_Approvals'", 5000)
                        //})

                   
                   // setTimeout("window.location = 'Pending_Approvals'", 5000)

                }

               
            });

        }



//var id;

//function getid() {
   
//    $('.userid a').click(function () {
//         id = $(this).text();
//       });
//}


//function getapprove() {
//    var id = $('#hdnid').val();
//    var PaymentRefNo = $('#PaymentRefNo').val();
//    var basepath = $('#basepath').val();
//    var InstanceId = $('#InstanceId').val();
//    var Token = $('#Token').val();
//    var Remarks = $('#Remarks').val();
   
//    $.ajax({

//        type: "POST",
//        //  url: '/Home/selectddata',
//        url: '/Admin/Approval_UsersData',
//        //    contentType: "application/json;",
//        data: { "id": id, "PaymentRefNo": PaymentRefNo, "basepath": basepath, "InstanceId": InstanceId, "Token": Token, "Remarks": Remarks }
        

//    });

//}
