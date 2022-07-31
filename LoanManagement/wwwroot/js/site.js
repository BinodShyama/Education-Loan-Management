// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("input.ndate").inputmask({ "mask": "9999-99-99" })
$('.select-chosen').chosen();
$('.toast').toast('show');

toastr.options = {
    toastClass: "toast", // toast class
    containerId: "toast-container", // container ID
    titleClass: "toast-title",
    messageClass: "toast-message",

    iconClasses: {// Customize icons here
        error: "toast-error",
        info: "toast-info",
        success: "toast-success",
        warning: "toast-warning"
    },
    iconClass: 'toast-default',
    closeButton: true,
    closeHtml: "<button class='btn-close btn-close-white'></button>",
    newestOnTop: true,

    // toast-top-center, toast-bottom-center, toast-top-full-width
    // toast-bottom-full-width, toast-top-left, toast-bottom-right
    // toast-bottom-left, toast-top-right
    positionClass: "toast-bottom-right",
    // allows HTML content in the toast?
    escapeHtml: false,
    preventDuplicates: false,
    //timeOut: 0,
    //extendedTimeOut: 0,
}