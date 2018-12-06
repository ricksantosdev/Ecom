
OFrame = {
    UserAgent: navigator.userAgent || navigator.vendor || window.opera
};

OFrame.ECOM = {
    RootSite: "/",
    Title: "",
    IsProcessing: false,
    Agent: {},
    Mobile: false,
    Browser: {
        ie: OFrame.UserAgent.indexOf("MSIE") > -1,
        ie6: OFrame.UserAgent.indexOf("MSIE 6") > -1,
        ie7: OFrame.UserAgent.indexOf("MSIE 7") > -1,
        ie8: OFrame.UserAgent.indexOf("MSIE 8") > -1,
        firefox: OFrame.UserAgent.indexOf("Firefox") > -1,
        opera: OFrame.UserAgent.indexOf("Opera") > -1,
        safari: OFrame.UserAgent.indexOf("Safari") > -1 && OFrame.UserAgent.indexOf("Chrome") == -1,
        chrome: OFrame.UserAgent.indexOf("Chrome") > -1,
        ios: /iPad|iPhone|iPod/.test(OFrame.UserAgent) && !window.MSStream,
        windows: /windows phone/i.test(OFrame.UserAgent),
        android: /android/i.test(OFrame.UserAgent)
    },
    SuccessMessage: "Opera\u00e7\u00e3o conclu\u00edda com sucesso.",
    ErrorMessage: "Falha ao efetuar opera\u00e7\u00e3o.",
    ValidateClasses: { groupIdentifier: ".form-group", error: 'has-error', success: null },
    Init: function () {
        if (window.location.hash.length > 0)
            OFrame.ECOM.OpenAjaxUrl(window.location.hash.replace('#', ''));

        $(document).ajaxStart(function () {
            OFrame.ECOM.IsProcessing = true;
            if (OFrame.ECOM.IsProcessing)
                OFrame.ECOM.ShowModalWait();
        });

        $(document).ajaxComplete(function () {
            setTimeout(function () {
                OFrame.ECOM.IsProcessing = false;
                OFrame.ECOM.HideModalWait();

                $(".ladda-button").each(function () {
                    var ladda = $(this);
                    ladda.ladda('stop');
                })

            }, 800);
        });

        $(document).ajaxError(function (e, jqXHR, ajaxSettings, thrownError) {

            OFrame.ECOM.IsProcessing = false;
            OFrame.ECOM.HideModalWait();

            var result = jQuery.parseJSON(jqXHR.responseText);

            // if 403 - check if user still has active session - if not redirect to login page
            if (jqXHR != null) {
                if (jqXHR.status == '403') {
                    window.location = OFrame.ECOM.RootSite + "Error/Denied";
                    return;
                }
            }

            if (!result.InternalError)
                OFrame.ECOM.ShowMessage("warning", "Aten\u00e7\u00e3o.", result.BusinessError);
            else
                OFrame.ECOM.ShowMessage("error", "Erro inesperado.", OFrame.ECOM.ErrorMessage);
        });

        // hack to open many bootstrap modals in same window        
        $('.modal').on('shown.bs.modal', function (event) {
            var idx = ($('.modal:visible').length) - 1; // raise backdrop after animation.
            $('.modal-backdrop').not('.stacked').css('z-index', 1039 + (10 * idx));
            $('.modal-backdrop').not('.stacked').addClass('stacked');
        });

        $('body').on('click', 'a', function (e) {

            e.preventDefault();
            var url = $(this).attr("href");

            if (url != "" && url != undefined) {
                if (url.indexOf("#") == -1)
                    OFrame.ECOM.OpenAjaxUrl(url, null);
            }
        });

        $('body').on('click', 'button[type=submit]', function (e) {

            var form = $(this).closest("form");
            var $submit = $(this);

            var validateOk = OFrame.ECOM.Form.Validate(form);

            setTimeout(function () {
                if (validateOk)
                    OFrame.ECOM.Form.SetButtonLoading($submit);
            }, 50);

            return validateOk;
        });

        $('body').on('focus', 'input, select', function (e) {

            if ($(this).attr("data-helper") != undefined) {

            }

        });

        $('#side-menu').on('click', function (ev) {
            setTimeout(function () {
                fix_height();
            }, 300);

            ev.preventDefault();
        });

        (function ($) {
            $(function () {
                $("form").each(function () {
                    try {
                        var validator = $(this).data('validator');
                        validator.settings.showErrors = OFrame.ECOM.OnValidated;
                    } catch (ex) { }
                });
            });
        }(jQuery));

        // Chrome fixed
        $.validator.addMethod(
            "date",
            function (value, element) {
                var check = false;
                var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
                if (re.test(value)) {
                    var adata = value.split('/');
                    var gg = parseInt(adata[0], 10);
                    var mm = parseInt(adata[1], 10);
                    var aaaa = parseInt(adata[2], 10);
                    var xdata = new Date(aaaa, mm - 1, gg);
                    if ((xdata.getFullYear() == aaaa) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == gg))
                        check = true;
                    else
                        check = false;
                } else
                    check = false;
                return this.optional(element) || check;
            },
            "Insira uma data v\u00e1lida"
        );

        // Client side validation logic.
        (function ($) {
            $.validator.addMethod(
                "futureDate",
                function (value, element) {
                    var curDate = new Date();
                    var values = value.split("/");
                    var newDate = values[2] + "/" + values[1] + "/" + values[0];
                    var valDate = new Date(newDate);
                    return (!value && this.optional(element)) || (valDate <= curDate);
                },
                "A data não pode ser maior que a data de hoje.");
            $.validator.unobtrusive.adapters.addBool("futureDate");

            // and an unobtrusive adapter
            $.validator.unobtrusive.adapters.add('futuredate', {}, function (options) {
                options.rules['futureDate'] = true;
                options.messages['futureDate'] = options.message;
            });

        }(jQuery));

        // Initialize toastr
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        //clippy.load('Clippy', function (agent) {
        //    OFrame.ECOM.Agent = agent;

        //    if (!OFrame.ECOM.IsMobile())
        //        agent.show();
        //});

        $.fn.serializeObject = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name] !== undefined) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };

        $("#button-back").off("click").click(function () {
            history.go(-1);
            setTimeout(function () {
                OFrame.ECOM.OpenAjaxUrl(window.location.href, null, null, false);
            }, 500);
            return false;
        });

        if (OFrame.ECOM.IsMobile()) {

            if (!$("body").hasClass("body-small"))
                $("body").addClass("mini-navbar");

            SmoothlyMenu();
        }

        /*setInterval(function () {
            var i = Math.floor(OFrame.ECOM.Tips.length * Math.random());
            OFrame.ECOM.Agent.speak(OFrame.ECOM.Tips[i]);
        }, 20000);*/

    },
    EncryptQueryUrl: function (data, callBackOk) {
        $.ajax({
            cache: false,
            type: "POST",
            url: OFrame.ECOM.RootSite + "Security/Encrypt",
            data: { "data": data },
            success: function (result) {
                if (!result.IsError) {
                    callBackOk(result);
                }
                else {
                    OFrame.ECOM.ShowMessage("danger", "Erro", result.Message);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                OFrame.ECOM.ShowMessage("danger", "Desculpe, ocorreu um erro na aplica\u00e7\u00e3o.", OFrame.ECOM.ErrorMessage);
            }
        });
    },
    ConfirmMessage: function (type, title, message, callbackOK, callbackNO) {

        swal({
            title: title,
            text: message,
            type: type,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Sim",
            cancelButtonText: "N\u00e3o",
            closeOnConfirm: true,
            closeOnCancel: true
        }, function (isConfirm) {
            if (isConfirm) {
                if (typeof callbackOK == 'function') {
                    callbackOK();
                }
            } else {
                if (typeof callbackNO == 'function') {
                    callbackNO();
                }
            }
        });

    },
    ShowMessage: function (type, title, message, callback) {

        var timer = 2500;

        sweetAlert({
            title: title,
            text: message,
            type: type,
            showCancelButton: false,
            confirmButtonText: "OK",
            timer: timer,
            showConfirmButton: false,
            closeOnConfirm: true
        });

        setTimeout(function () {
            if (typeof callback == 'function') {
                callback();
            }

            OFrame.ECOM.Agent.stop();
            OFrame.ECOM.Agent.speak(message);

            switch (type) {
                case "success":
                    OFrame.ECOM.Agent.play('Congratulate');
                    toastr.success(message, title);
                    break;
                case "error":
                    toastr.error(message, title);
                    break;
                case "warning":
                    toastr.warning(message, title);
                    break;
                case "info":
                    toastr.info(message, title);
                    break;
            }
        }, (timer + 300));

    },
    ShowNotification: function (type, title, message, callback) {

        switch (type) {
            case "success":
                toastr.success(message, title);
                break;
            case "error":
                toastr.error(message, title);
                break;
            case "warning":
                toastr.warning(message, title);
                break;
            case "info":
                toastr.info(message, title);
                break;
        }

        if (typeof callback == 'function') {
            callback();
        }

    },
    FilterSuccess: function (content, html, collapseSelector) {
        $(content).html(html);
        $(collapseSelector).click();

        if (!$("body").hasClass("body-small"))
            $("body").addClass("mini-navbar");

        SmoothlyMenu();
    },
    FindBootstrapEnvironment: function () {
        var envs = ['xs', 'sm', 'md', 'lg'];

        var $el = $('<div>');
        $el.appendTo($('body'));

        for (var i = envs.length - 1; i >= 0; i--) {
            var env = envs[i];

            $el.addClass('hidden-' + env);
            if ($el.is(':hidden')) {
                $el.remove();
                return env;
            }
        }
    },
    IsMobile: function () {
        var isMobile = OFrame.ECOM.FindBootstrapEnvironment() != "lg" && OFrame.ECOM.FindBootstrapEnvironment() != "md";

        if (OFrame.ECOM.Mobile)
            isMobile = true;

        return isMobile;
    },
    Form: {
        Success: function (result, form, callback) {
            var $form = $(form);

            var title = $form.attr("title");
            var sucessMessage = $form.attr("message") == undefined ? result.MessageOK == undefined ? OFrame.ECOM.SuccessMessage : result.MessageOK : $form.attr("message");
            var urlBack = $form.attr("urlBack");

            if (!result.HasError && result.HasError != undefined) {
                // Verify if exists return function
                if (typeof callback == 'function') { callback(result); }

                OFrame.ECOM.ShowMessage("success", title, sucessMessage, function () {
                    if (urlBack != "")
                        OFrame.ECOM.OpenAjaxUrl(urlBack);
                });
            }
            else {
                if (!result.InternalError)
                    OFrame.ECOM.ShowMessage("warning", "Aten\u00e7\u00e3o.", result.BusinessError);
                else
                    OFrame.ECOM.ShowMessage("error", "Erro inesperado.", OFrame.ECOM.ErrorMessage);
            }
        },
        Error: function (result) {
            OFrame.ECOM.ShowMessage("error", "Erro inesperado.", OFrame.ECOM.ErrorMessage);
        },
        Validate: function (form) {
            $.validator.unobtrusive.parse(form);

            $(form).each(function () {
                var validator = $(this).data('validator');

                if (validator)
                    validator.settings.showErrors = OFrame.ECOM.OnValidated;
            });

            return $(form).validate().form();
        },
        SetDefaultButton: function (target) {
            $(OFrame.ECOM.Form.FormName).bind("keydown", function (e) {
                if (event.keyCode == 13 && !(event.srcElement.type == "textarea")) {

                    var doit = true;

                    if ($(".bootstrap-dialog-header").is(":visible") == true)
                        doit = false;

                    if ($("[type=reset]").is(":focus") == true)
                        doit = false;

                    if (doit)
                        $(target).click();
                }
            });
        },
        SetButtonLoading: function ($button) {
            $button.addClass("ladda-button");
            $button.attr("data-style", "expand-right");

            var l = $button.ladda();

            l.ladda('start');
        },

        SetAutoComplete: function (_selector, _displayKey, _url) {

            var pageSize = 9999;

            $(_selector).select2(
                {
                    placeholder: 'Entre com o ' + _displayKey,
                    //Does the user have to enter any data before sending the ajax request
                    minimumInputLength: 0,
                    allowClear: true,
                    ajax: {
                        //How long the user has to pause their typing before sending the next request
                        global: false,
                        quietMillis: 150,
                        //The url of the json service
                        url: _url,
                        dataType: 'json',
                        delay: 250,
                        data: function (params) {
                            return {
                                search: params.term, // search term
                                page: params.page
                            };
                        },
                        processResults: function (data, params) {
                            // parse the results into the format expected by Select2
                            // since we are using custom formatting functions we do not need to
                            // alter the remote JSON data, except to indicate that infinite
                            // scrolling can be used                                                
                            params.page = params.page || 1;

                            return {
                                results: data.items,
                                pagination: {
                                    more: (params.page * 30) < data.total_count
                                }
                            };
                        },
                        cache: true
                    },
                    escapeMarkup: function (markup) { return markup; }, // let our custom formatter work                
                    //templateResult: formatRepo, // omitted for brevity, see the source of this page
                    //templateSelection: formatRepoSelection // omitted for brevity, see the source of this page
                });

        },
        SetFocus: function (control) {
            if ($.browser.msie) {
                var obj_form = document.getElementById(control.replace("#", ""));
                if (obj_form != null) { setTimeout(function () { obj_form.focus(); }, 300); }
            }
            else {
                setTimeout(function () { $(control)[0].focus(); }, 100);
            }
        },
        DateFormat: function (currentEvent, object) {

            var keypress = (window.event) ? event.keyCode : currentEvent.which;
            field = eval(object);
            if (field.value == '00/00/0000 00:00:00') {
                field.value = ""
            }

            characters = '0123456789';
            separator1 = '/';
            separator2 = '';// separator2 = ' ';
            separator3 = ':';
            group1 = 2;
            group2 = 5;
            group3 = 10;
            group4 = 13;
            group5 = 16;
            if ((characters.search(String.fromCharCode(keypress)) != -1) && field.value.length < (19)) {
                if (field.value.length == group1)
                    field.value = field.value + separator1;
                else if (field.value.length == group2)
                    field.value = field.value + separator1;
                else if (field.value.length == group3)
                    field.value = field.value + separator2;
                else if (field.value.length == group4)
                    field.value = field.value + separator3;
                else if (field.value.length == group5)
                    field.value = field.value + separator3;
            }
            else
                event.returnValue = false;
        }
    },
    Table: {
        GetDefault: function (table, options, scrollX) {

            if (options == null) {

                var aoColumns = [];

                // hack for mobile
                $(table).attr("style", "width: 100%;");

                $(table + " thead th").each(function () {
                    if ($(this).hasClass('no-sort')) {
                        aoColumns.push({ "bSortable": false });
                    } else {
                        aoColumns.push(null);
                    }
                });

                var isModal = $(table).closest(".modal").hasClass("modal");

                var exportOptions = (!isModal) ? !OFrame.ECOM.IsMobile() ? [
                    'copy', 'excel', 'pdf',
                    {
                        extend: 'print',
                        exportOptions: {
                            columns: ':visible'
                        }
                    }, 'colvis'] : ['colvis']
                    : !OFrame.ECOM.IsMobile() ? [
                        'copy', 'excel', 'pdf',
                        {
                            extend: 'print',
                            exportOptions: {
                                columns: ':visible'
                            }
                        }
                    ] : ['colvis'];

                return $(table).DataTable({
                    "autoWidth": true,
                    "paging": true,
                    "bLengthChange": !OFrame.ECOM.IsMobile(),
                    "scrollX": OFrame.ECOM.IsMobile() ? true : scrollX ? true : false,
                    "iDisplayLength": 10,
                    bFilter: !$(table).hasClass("no-filter"),
                    dom: '<"html5buttons"B>lTfgitp',
                    "aoColumns": aoColumns,
                    buttons: exportOptions,
                    "order": [[0, "desc"]],
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, OFrame.ECOM.LabelAll]],
                    "language": '',
                    //destroy: true
                });
            }
            else {
                return $(table).dataTable(options);
            }
        }
    },
    ShowContentWait: function (form) {
        OFrame.ECOM.HideModalWait();
        var content = $(form).attr("data-ajax-update");
        $(content).html('<div id="contentloading"></div>');
    },
    ShowModalWait: function () {
        $('#splashscreen').show();
    },
    HideModalWait: function () {
        $('#splashscreen').hide();
    },
    SetCookie: function (cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + "; " + expires;
    },
    GetCookie: function (cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1);
            if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
        }
        return "";
    },
    OpenAjaxUrl: function (url, content, callback, hash) {

        if (!content) {
            content = '.body-content';
        }

        $(content).html('<div id="contentloading"></div>');

        if (url.indexOf("http") == -1) {
            url = url.replace(OFrame.ECOM.RootSite, "");
            url = OFrame.ECOM.RootSite + url;

            if (url.indexOf("//") > -1)
                url = url.replace("//", "/");
        }
        else {
            url = url.replace("#/", "");
            url = url.replace("?mobile=1", "/");

            // fix for url back button
            if (OFrame.ECOM.RootSite.length > 1) {
                var rootAddress = OFrame.ECOM.RootSite.replace("/", "").replace("/", "");

                if (url.toLowerCase().split(rootAddress.toLowerCase()).length > 2)
                    url = url.replace(rootAddress, "");
            }
        }

        if (hash == undefined || hash == true)
            window.location.hash = url;

        $.ajax({
            url: url,
            global: true,
            dataType: 'html',
            success: function (data) {
                $(content).html(data);

                if (typeof callback == 'function') {
                    callback();
                }
            },
            error: function (data) {
                $(content).html(data);
            }
        });

        OFrame.ECOM.HideModalWait();

        return false;
    },
    PostAjaxUrl: function (url, content, params, callback) {

        if (!content) {
            content = '.body-content';
        }

        $(content).html('<div id="contentloading"></div>');

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            global: true,
            data: params,
            dataType: 'html',
            success: function (data) {
                $(content).html(data);

                if (typeof callback == 'function') {
                    callback();
                }
            },
            error: function (data) {
                $(content).html(data);
            }
        });

        OFrame.ECOM.HideModalWait();

        return false;
    },
    PostWidget: function (url, content, params, interval, callback) {

        OFrame.ECOM.PostAjaxUrl(url, content, params, interval, callback);

        setInterval(function () {

            OFrame.ECOM.PostAjaxUrl(url, content, params, interval, callback);

        }, interval)

        return false;
    },
    FormatJSON: function (json) {
        return json.replace(/&amp;/g, "&").replace(/&quot;/g, '"');
    },
    LimitStr: function (str) {
        if (str != "") {
            return str.length > 30 ? str.substring(0, 30) + "..." : str;
        }

        return str;
    },
    TruncateStr: function (str) {

        if (str.length < 11) {
            return str;
        }

        var truncate_str = "";

        if (str.split('<br/>').length == 0)
            return str.split('<br/>')[0].substring(0, 10) + "...";

        for (var i = 0; i < str.split('<br/>').length; i++) {

            var current_str = str.split('<br/>')[i];

            truncate_str += current_str.length > 10 ? current_str.substring(0, 10) + "..." + "<br>" : current_str + "<br>";

        }

        return truncate_str;

    },
    ValidateOnlyNumeric: function (evt) {

        if (evt.shiftKey == true || evt.ctrlKey == true || evt.altKey == true)
            return false;

        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57)
            && (charCode < 96 || charCode > 105))
            return false;

        return true;
    },
    DisableRightClick: function (controlName) {

        $(controlName).bind('contextmenu', function (e) {
            e.preventDefault();
        });
    },

    DisableRightClickInput: function (control) {

        $(control).bind('contextmenu', function (e) {
            e.preventDefault();
        });
    },
    ValidateRanger: function (comp, min, max) {
        // Valida se o valor esta dentro do ranger        
        if (comp.value < min || comp.value > max)
            comp.select();
    },

    UpdateClasses: function (inputElement, toAdd, toRemove) {

        var group = inputElement.closest(OFrame.ECOM.ValidateClasses.groupIdentifier);
        if (group.length > 0) {
            if (toRemove != null) {
                $errorSpan = $("span[data-valmsg-for='" + inputElement.attr("name") + "']");
                $errorSpan.hide();
            }

            group.addClass(toAdd).removeClass(toRemove);
        }
    },
    OnError: function (inputElement, message) {
        OFrame.ECOM.UpdateClasses(inputElement, OFrame.ECOM.ValidateClasses.error, OFrame.ECOM.ValidateClasses.success);
        $errorSpan = $("span[data-valmsg-for='" + inputElement.attr("name") + "']");
        $errorSpan.html("<span class='error'>" + message + "</span>");
        $errorSpan.show();

        inputElement.addClass("error");
    },
    OnSuccess: function (inputElement) {
        OFrame.ECOM.UpdateClasses(inputElement, OFrame.ECOM.ValidateClasses.success, OFrame.ECOM.ValidateClasses.error);
    },

    OnValidated: function (errorMap, errorList) {

        $.each(errorList, function () {
            OFrame.ECOM.OnError($(this.element), this.message);
        });

        if (this.settings.success) {
            $.each(this.successList, function () {
                OFrame.ECOM.OnSuccess($(this));
            });
        }
    }
};