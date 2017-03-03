var track = false;
$(document).ready(function () {
    var $generalCategory = $("#GeneralCategoryID");
    var $category = $("#CategoryID");
    var $subCategoryName = $("#SubCategoryName");
    var $subCategoryCode = $("#SubCategoryCode");
    var $subCategoryNameExist = $("#sub-category-name-exist");
    var $subCategoryCodeExist = $("#sub-category-code-exist");
    var $form = $("form");

    var categoryDefaultOption = "<option value=''>Select a Category</option>";
    var subCategoryNameValue;
    var subCategoryCodeValue;

    var generalCategoryId;
    var categoryId;

    $generalCategory.change(function () {
        generalCategoryId = parseInt($generalCategory.val());
        if (generalCategoryId > 0) {
            getAllCategories();
        } else {
            $category.empty().append(categoryDefaultOption);
            $subCategoryCodeExist.empty();
            $subCategoryNameExist.empty();
        }
    });

    function getAllCategories() {
        $.ajax({
            url: "/Category/GetAllByGeneralCategoryId",
            data: { generalCategoryId: generalCategoryId },
            method: "POST",
            success: function (result) {
                var option = categoryDefaultOption;
                for (var i = 0; i < result.length; i++) {
                    option = option + "<option value='" + result[i]['CategoryID'] + "'>" + result[i]['CategoryName'] + "</option>";
                }
                $category.empty().append(option);
            }
        });
    }

    $category.change(function () {
        categoryId = parseInt($category.val());
        if (categoryId > 0) {
            subCategoryCodeValue = $subCategoryCode.val();
            subCategoryNameValue = $subCategoryName.val();
            checkCodeAvailability(checkNameAvailability());
        } else {
            $subCategoryCodeExist.empty();
            $subCategoryNameExist.empty();
        }
    });

    $subCategoryName.change(function () {
        subCategoryNameValue = $subCategoryName.val();
        if (subCategoryNameValue !== "") {
            checkNameAvailability();
        } else {
            $subCategoryNameExist.empty();
        }
    });

    function checkNameAvailability() {
        $.ajax({
            url: "/SubCategory/IsNameAvailable",
            data: { subCategoryName: subCategoryNameValue, categoryId: categoryId },
            method: "POST",
            success: function (result) {
                if (result !== true) {
                    track = false;
                    $subCategoryNameExist.empty().append("Name Already Exist");
                } else {
                    track = true;
                    $subCategoryNameExist.empty();
                }
            }
        });
    }

    $subCategoryCode.change(function () {
        subCategoryCodeValue = $subCategoryCode.val();
        if (subCategoryCodeValue !== "") {
            checkCodeAvailability();
        }
        else {
            $subCategoryCodeExist.empty();
        }
    });

    function checkCodeAvailability() {
        $.ajax({
            url: "/SubCategory/IsCodeAvailable",
            data: { subCategoryCode: subCategoryCodeValue, categoryId: categoryId },
            method: "POST",
            success: function (result) {
                if (result !== true) {
                    track = false;
                    $subCategoryCodeExist.empty().append("Code Already Exist");
                } else {
                    track = true;
                    $subCategoryCodeExist.empty();
                }
            }
        });
    }

    $form.submit(function (e) {
        e.preventDefault();
        if ($form.valid() && track === true) {
            $(this).unbind("submit").submit();
        }
    });
});