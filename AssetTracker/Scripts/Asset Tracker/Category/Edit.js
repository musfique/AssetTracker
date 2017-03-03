var track = true;
$(document).ready(function () {
    var $generalCategory = $("#GeneralCategoryID");
    var $categoryName = $("#CategoryName");
    var $categoryCode = $("#CategoryCode");
    var $categoryNameExist = $("#category-name-exist");
    var $categoryCodeExist = $("#category-code-exist");
    var $form = $("form");

    var generalCategoryId, categoryNameValue, categoryCodeValue;

    var categoryId = $("#CategoryID").val();

    $generalCategory.change(function () {
        generalCategoryId = parseInt($generalCategory.val());
        categoryNameValue = $categoryName.val();
        categoryCodeValue = $categoryCode.val();
        if (generalCategoryId > 0 && categoryNameValue !== "" && categoryCodeValue !== "" && categoryCodeValue.length === 3) {
            checkCodeAvailability(checkNameAvailability());
        }

    });

    $categoryName.change(function () {
        generalCategoryId = parseInt($generalCategory.val());
        categoryNameValue = $categoryName.val();
        if (generalCategoryId > 0 && categoryNameValue !== "") {
            checkNameAvailability();
        }

    });
    $categoryCode.change(function () {
        generalCategoryId = parseInt($generalCategory.val());
        categoryCodeValue = $categoryCode.val();
        if (generalCategoryId > 0 && categoryCodeValue !== "" && categoryCodeValue.length === 3) {
            checkCodeAvailability();
        }

    });

    function checkNameAvailability() {
        $.ajax({
            url: "/Category/IsCategoryNameAvailableWithId",
            data: { generalCategoryId: generalCategoryId, categoryName: categoryNameValue, categoryId: categoryId },
            method: "POST",
            success: (function (result) {
                //console.log("Name " + result);
                if (result !== true) {
                    track = false;
                    $categoryNameExist.empty().append("Name is not available");
                } else {
                    track = true;
                    $categoryNameExist.empty();
                }
            })
        });
    }

    function checkCodeAvailability() {
        $.ajax({
            url: "/Category/IsCategoryCodeAvailableWithId",
            data: { generalCategoryId: generalCategoryId, categoryCode: categoryCodeValue, categoryId: categoryId },
            method: "POST",
            success: (function (result) {
                //console.log("Code " + result);
                if (result !== true) {
                    track = false;
                    $categoryCodeExist.empty().append("Code is not available");
                } else {
                    track = true;
                    $categoryCodeExist.empty();
                }
            })
        });
    }

    $form.submit(function (e) {
        e.preventDefault();
        if ($form.valid() && track === true) {
            $(this).unbind("submit").submit();
        }
    });

});