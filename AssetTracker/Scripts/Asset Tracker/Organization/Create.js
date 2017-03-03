$(document).ready(function () {
    var $organization = $("#OrganizationID");
    var $organizationBranch = $("#OrganizationBranchID");

    $organization.change(function () {
        var organizationId = $organization.val();
        if (organizationId !== "") {
            $.ajax({
                url: "/OrganizationBranch/GetOrganizationBranches",
                data: { id: organizationId },
                method: "POST",
                success: function (result) {
                    //console.log(result);
                    var options = "<option value=''>Select a Branch</option>";
                    for (var i = 0; i < result.length; i++) {
                        options = options + "<option value='" + result[i]['OrganizationBranchID'] + "'>" + result[i]['OrganizationBranchName'] + "</option>";
                    }
                    $organizationBranch.empty().append(options);
                }


            });
        } else {
            var options = "<option value=''>Select a Branch</option>";
            $organizationBranch.empty().append(options);
        }

    });
});