var track = true;
$(document).ready(function () {
    var $generalCategory = $("#GeneralCategoryID");
    var $category = $("#CategoryID");
    var $subCategory = $("#SubCategoryID");
    var $detailCategoryName = $("#DetailCategoryName");
    var $detailCategoryCode = $("#DetailCategoryCode");
    var $detailCategoryNameExist = $("#detail-category-name-exist");
    var $detailCategoryCodeExist = $("#detail-category-code-exist");
    var $form = $("form");
    var categoryDefaultOption = "<option value=''>Select a Category</option>";
    var subCategoryDefaultOption = "<option value=''>Select a Sub Category</option>";

    var generalCategoryId, categoryId, subCategoryId,detailCategoryId=$("#DetailCategoryID").val();
    var detailCategoryNameValue, detailCategoryCodeValue;

    $generalCategory.change(function () {
        generalCategoryId = parseInt($generalCategory.val());
        if (generalCategoryId > 0) {
            getAllCategories();
            $subCategory.empty().append(subCategoryDefaultOption);
        } else {
            $category.empty().append(categoryDefaultOption);
            $subCategory.empty().append(subCategoryDefaultOption);

            $detailCategoryNameExist.empty();
            $detailCategoryCodeExist.empty();
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
            getAllSubCategories();
        } else {
            $subCategory.empty().append(subCategoryDefaultOption);

            $detailCategoryCodeExist.empty();
            $detailCategoryNameExist.empty();
        }
    });

    function getAllSubCategories() {
        $.ajax({
            url: "/SubCategory/GetAllByCategoryId",
            data: { categoryId: categoryId },
            method: "POST",
            success: function (result) {
                var option = subCategoryDefaultOption;
                for (var i = 0; i < result.length; i++) {
                    option = option + "<option value='" + result[i]['SubCategoryID'] + "'>" + result[i]['SubCategoryName'] + "</option>";
                }
                $subCategory.empty().append(option);
            }
        });
    }

    $subCategory.change(function () {
        subCategoryId = parseInt($subCategory.val());
        if (subCategoryId > 0) {
            detailCategoryNameValue = $detailCategoryName.val();
            detailCategoryCodeValue = $detailCategoryCode.val();
            checkCodeAvailability(checkNameAvailability());
        }
    });

    $detailCategoryName.change(function () {
        subCategoryId = parseInt($subCategory.val());
        detailCategoryNameValue = $detailCategoryName.val();
        if (detailCategoryNameValue !== "") {
            checkNameAvailability();
        } else {
            $detailCategoryNameExist.empty();
        }
    });

    function checkNameAvailability() {
        $.ajax({
            url: "/DetailCategory/IsNameAvailableWithId",
            data: { detailCategoryName: detailCategoryNameValue, detailCategoryId: detailCategoryId, subCategoryId: subCategoryId },
            method: "POST",
            success: function (result) {
                if (result !== true) {
                    track = false;
                    $detailCategoryNameExist.empty().append("Name Already Exist");
                } else {
                    track = true;
                    $detailCategoryNameExist.empty();
                }
            }
        });
    }

    $detailCategoryCode.change(function () {
        subCategoryId = parseInt($subCategory.val());
        detailCategoryCodeValue = $detailCategoryCode.val();
        if (detailCategoryCodeValue !== "") {
            checkCodeAvailability();
        } else {
            $detailCategoryCodeExist.empty();
        }
    });

    function checkCodeAvailability() {
        $.ajax({
            url: "/DetailCategory/IsCodeAvailableWithId",
            data: { detailCategoryCode: detailCategoryCodeValue, detailCategoryId: detailCategoryId, subCategoryId: subCategoryId },
            method: "POST",
            success: function (result) {
                if (result !== true) {
                    track = false;
                    $detailCategoryCodeExist.empty().append("Code Already Exist");
                } else {
                    track = true;
                    $detailCategoryCodeExist.empty();
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