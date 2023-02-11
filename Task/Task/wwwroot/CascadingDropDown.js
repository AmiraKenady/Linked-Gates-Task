$(document).ready(function () {
    $("#cat").change(function () {
        var selectedCategory = $("#cat").val();
        console.log(selectedCategory)
        $.ajax({
            type: "GET",
            url: "/Home/GetProperties",
            data: { catid: selectedCategory },
            success: function (data) {
                console.log(data)
                $("#propertiesContainer").empty();
                $.each(data, function (index, property) {
                    var propertyDiv = $("<div></div>");
                    propertyDiv.append("<label class='m-3'>" + property.value + ": </label>");
                    var input1 = $("<input class='form-control' type='text' name='Properties[" + index + "].value' />");
                    var input2 = $(" <input type='text' hidden name='Properties[" + index + "].propertyId' value = '" + property.pid + "' />")
                    propertyDiv.append(input1);
                    propertyDiv.append(input2);
                    $("#propertiesContainer").append(propertyDiv);
                });
            }
            
        });
    });
});
