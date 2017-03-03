$(document).ready(function () {
    var $organization = $("#OrganizationID");
    var $organizationBranch = $("#OrganizationBranchID");
    var $deparment = $("#DepartmentID");
    var organanizationBranchDefaultOption = "<option value=''>Select a Branch</option>";
    var departmentDefaultOption = "<option value=''>Select a Department</option>";

    $organization.change(function () {
        var organizationId = $organization.val();
        if (organizationId !== "") {
            $.ajax({
                url: "/OrganizationBranch/GetOrganizationBranches",
                data: { id: organizationId },
                method: "POST",
                success: function (result) {
                    //console.log(result);
                    var options = organanizationBranchDefaultOption;
                    for (var i = 0; i < result.length; i++) {
                        options = options + "<option value='" + result[i]['OrganizationBranchID'] + "'>" + result[i]['OrganizationBranchName'] + "</option>";
                    }
                    $organizationBranch.empty().append(options);
                }


            });
        } else {
            $organizationBranch.empty().append(organanizationBranchDefaultOption);
            $deparment.empty().append(departmentDefaultOption);
        }

    });
    $organizationBranch.change(function () {
        var organizationBranchId = $organizationBranch.val();
        if (organizationBranchId !== "") {
            $.ajax({
                url: "/Department/GetDepartments",
                data: { id: organizationBranchId },
                method: "POST",
                success: function (result) {
                    //console.log(result);
                    var options = departmentDefaultOption;
                    for (var i = 0; i < result.length; i++) {
                        options = options + "<option value='" + result[i]['DepartmentID'] + "'>" + result[i]['DepartmentName'] + "</option>";
                    }
                    $deparment.empty().append(options);
                }


            });
        } else {
            $organizationBranch.empty().append(organanizationBranchDefaultOption);
            $deparment.empty().append(departmentDefaultOption);
        }
    });

});