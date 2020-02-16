

$(document).ready(function(){
    $("#SearchName").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#mytable tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

function CloseDiv() {
    var x = document.getElementById("DeleteEmployee");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function DeleteEmp(item) {
    $("#DeleteEmployee").css("display", "block");
    var EmployeeID = $(item).data('content');
    $("#EmployeeID").val(EmployeeID);
}

$(document).ready(function () {
    $("#AddNewDep").click(function () {
        var data = $("#FormSubmitNewDep").serialize();
        $.ajax({
            type: "POST",
            url: "/Departs/Create",
            data: data,
            success: function (response) {
                alert("New Department Added");
                var url = "/Departs/Index";
                window.location.href = url;
            }
        })
    })
})

$(document).ready(function () {
    $("#EditDep").click(function () {
        var data = $("#FormSubmitEditDep").serialize();
        $.ajax({
            type: "POST",
            url: "/Departs/Edit",
            data: data,
            success: function (response) {
                alert("New Department Updated");
                var url = "/Departs/Index";
                window.location.href = url;
            }
        })
    })
})

$(document).ready(function () {
    $("#AddNewEmp").click(function () {

        if ($("#UploadImage").val() == "") {
            $("#error-div").fadeIn();
            $("#view-error").append("Please Choose Image");
            return false;
        }
    })
})
