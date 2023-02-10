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
                    var input = $("<input class='form-control m-3' type='text' name='" + property.value + "' />");
                    input.val(property.Value);
                    propertyDiv.append(input);
                    $("#propertiesContainer").append(propertyDiv);
                });
            }
        });
    });
});
