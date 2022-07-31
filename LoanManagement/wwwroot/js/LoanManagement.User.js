
var User = function () {
    this.LoadUser = function () {
        $('#user-dt').DataTable({
            processing: true,
            responsive: true,
            type: "GET",
            scrollX: true,
            columns: [
                { "data": "name", "title": "Name" },
                { "data": "userName", "title": "UserName" },
                { "data": "email", "title": "Email" },
                { "data": "status", "title": "Status" },
                { "data": "action", "title": "", "orderable":false, width: "20px" }
            ],
            ajax: '/api/user',
        });

    }


    $(document).ready(function () {
        LoadUser();

    });
}
User();