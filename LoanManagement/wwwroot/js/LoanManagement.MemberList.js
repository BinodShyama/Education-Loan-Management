var dataTable = {};
var Member =  {
    LoadMember : function () {
        dataTable= $('#member-dt').DataTable({
            "processing": true,
            "responsive": true,
            "serverSide": true,
            "scrollX": true,
            "ordering": true,
            "paging": true,
            "searching": true,
            "ajax": {
                "url": '/Member/List',
                "type": 'POST',
                "data": function (d) {
                    d.searchModel= {
                        gender: $('#gender').val(),
                        ward: $('#ward').val(),
                        degree: $('#degree').val(),
                        instiution: $('#institution').val(),
                        university: $('#university').val()
                    }
                },
                "dataSrc": function (d) {
                    // Format API response for DataTables
                    var response = d;
                    if (typeof d.response != 'undefined') {
                        response = d.response;
                    }
                    return response.data;
                }
            },
            "columns": [
                {
                    "data": "name", "title": "Name", render: function (data,display,row,a) {
                        return "<a class='btn-link' href='/member/view/"+row.id+"'>"+data+"</a>";
                    }
                },
                { "data": "gender", "title": "Gender" },
                { "data": "fatherName", "title": "Father Name." },
                { "data": "mobileNumber", "title": "Contact No." },
                { "data": "address", "title": "Address" },
                { "data": "wardNumber", "title": "Ward No." },
                { "data": "degree", "title": "Degree" },
                { "data": "institution", "title": "Institution" },
                { "data": "university", "title": "University" },
                { "data": "citizenShipNumber", "title": "Citizenship No." },
                { "data": "nationalIdentiryCardNumber", "title": "National Identity Card No." },
                {
                    "data": "sanctionAmount", "title": "Sanction Amount(Rs.)", render: function (data,d,row,a) {
                        if (data > 0) {
                            return "<a href='/MemberLoanDetail/Edit/"+ row.id+"'><span class='badge badge-pill badge-info'>Rs. "+data+"</span></a>"
                        } else {
                           return "<a href='/MemberLoanDetail/Create/"+row.id+"'><span class='badge badge-pill badge-warning'>Not Allocated</span></a>"
                        }
                    }
                },
            ],

        });
    },

   dataTableFilter :function () {
        dataTable.ajax.reload();
    },

    dataTableClearFilter : function () {
        $('.select-chosen').val('')
        $('.select-chosen').trigger("chosen:updated");
        dataTable.ajax.reload();
    }

   
}
$(document).ready(function () {
    Member.LoadMember();
});
