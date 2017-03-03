$(document).ready(function () {
    var $organization = $("#OrganizationID");
    var $organizationBranchShortName = $("#OrganizatioBranchShortName");
    var $organizationBranchShortNameExist = $("#organization-branch-short-name-exist");
    var organizationValue;
    var organizationBranchShortNameValue;
    var existMsg = "Short Name already Exist.";
    var $form = $("form");
    var track = false;

    $organization.change(function () {
        organizationValue = parseInt($organization.val());
        organizationBranchShortNameValue = $organizationBranchShortName.val();
        if (organizationValue > 0 && organizationBranchShortNameValue !== "") {
            checkShortNameAvailbility();
        } else {
            $organizationBranchShortNameExist.empty();
            track = true;
        }
    });

    $organizationBranchShortName.change(function () {
        organizationValue = parseInt($organization.val());
        organizationBranchShortNameValue = $organizationBranchShortName.val();
        if (organizationValue > 0 && organizationBranchShortNameValue !== "") {
            checkShortNameAvailbility();
        } else {
            $organizationBranchShortNameExist.empty();
            track = true;
        }
    });

    function checkShortNameAvailbility() {
        $.ajax({
            url: "/OrganizationBranch/IsShortNameAvailable",
            method: "POST",
            data: { organizationBranchShortName: organizationBranchShortNameValue },
            success: (function (result) {
                if (result === true) {
                    $organizationBranchShortNameExist.empty();
                    track = true;
                } else {
                    $organizationBranchShortNameExist.empty().append(existMsg);
                    track = false;
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