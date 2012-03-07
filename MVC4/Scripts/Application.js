/// <reference path="cdn/jquery-1.7.1.js" />

$(function ($) {

    init(this);
});

function init(container) {

    Application.loadAjax(container);

    InlineEdit.init(container);
    
}

var Application = {
    loadAjax: function(container) {
        var ajaxElements = $(container).find("[data-type='ajaxload']");
        ajaxElements.each(function() {
            Application.loadAjaxElement($(this));
        });
    },

    loadAjaxElement: function(element) {
        var updateId = element.data('updateid');
        var url = element.data('url');

        $('#' + updateId).load(url, function() {
            if (typeof init == 'function') {
                init(element);
            }
        });
        return false;
    }
};

var InlineEdit = {
    init: function(container) {
        $(container).find("[data-editable='textbox']").each(function () {
            var url = $(this).data("updateurl");
            var itemIdElement = $(this).closest("[data-modelid]");
            
            if (itemIdElement.length == 0) {
                alert("Missing modelid attribute");
                return false;
            }

            var itemId = itemIdElement.data("modelid");
            
            $(this).editable(url, {
                cancel: 'Cancel',
                submit: 'OK',
                submitdata: {
                    itemId: itemId
                }
            });
        });
    
    }
};
