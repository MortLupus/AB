

//$(function ($) {
//    $("#file").fileupload();
//})



//(function ($) {
//    var n = 'undefined',
//        func = 'function',
//        UploadHandler, methods, MultiLoader = function (b) {
//            var c = 0,
//                list = [];
//            this.complete = function () {
//                c += 1;
//                if (c === list.length + 1) {
//                    b(list);
//                    c = 0;
//                    list = []
//                }
//            };
//            this.push = function (a) {
//                list.push(a)
//            };
//            this.getList = function () {
//                return list
//            }
//        };
//    UploadHandler = function (k, l) {
//        var m = this,
//            dragOverTimeout, isDropZoneEnlarged, multiLoader = new MultiLoader(function (a) {
//                m.hideProgressBarAll(function () {
//                    m.resetProgressBarAll();
//                    if (typeof m.onCompleteAll === func) {
//                        m.onCompleteAll(a)
//                    }
//                })
//            }),
//            getUploadTable = function (a) {
//                return typeof a.uploadTable === func ? a.uploadTable(a) : a.uploadTable
//            },
//            getDownloadTable = function (a) {
//                return typeof a.downloadTable === func ? a.downloadTable(a) : a.downloadTable
//            };
//        this.requestHeaders = {
//            'Accept': 'application/json, text/javascript, */*; q=0.01'
//        };
//        this.dropZone = k;
//        this.imageTypes = /^image\/(gif|jpeg|png)$/;
//        this.previewMaxWidth = this.previewMaxHeight = 80;
//        this.previewLoadDelay = 100;
//        this.previewAsCanvas = true;
//        this.previewSelector = '.file_upload_preview';
//        this.progressSelector = '.file_upload_progress div';
//        this.cancelSelector = '.file_upload_cancel button';
//        this.cssClassSmall = 'file_upload_small';
//        this.cssClassLarge = 'file_upload_large';
//        this.cssClassHighlight = 'file_upload_highlight';
//        this.dropEffect = 'highlight';
//        this.uploadTable = this.downloadTable = null;
//        this.buildUploadRow = this.buildDownloadRow = null;
//        this.progressAllNode = null;
//        this.loadImage = function (c, d, f, g, h, i) {
//            var j, scaleImage, urlAPI, fileReader;
//            if (h && !h.test(c.type)) {
//                return null
//            }
//            scaleImage = function (a) {
//                var b = document.createElement('canvas'),
//                    scale = Math.min((f || a.width) / a.width, (g || a.height) / a.height);
//                if (scale > 1) {
//                    scale = 1
//                }
//                a.width = parseInt(a.width * scale, 10);
//                a.height = parseInt(a.height * scale, 10);
//                if (i || typeof b.getContext !== func) {
//                    return a
//                }
//                b.width = a.width;
//                b.height = a.height;
//                b.getContext('2d').drawImage(a, 0, 0, a.width, a.height);
//                return b
//            };
//            j = document.createElement('img');
//            urlAPI = typeof URL !== n ? URL : typeof webkitURL !== n ? webkitURL : null;
//            if (urlAPI && typeof urlAPI.createObjectURL === func) {
//                j.onload = function () {
//                    urlAPI.revokeObjectURL(this.src);
//                    d(scaleImage(j))
//                };
//                j.src = urlAPI.createObjectURL(c)
//            } else if (typeof FileReader !== n && typeof FileReader.prototype.readAsDataURL === func) {
//                j.onload = function () {
//                    d(scaleImage(j))
//                };
//                fileReader = new FileReader();
//                fileReader.onload = function (e) {
//                    j.src = e.target.result
//                };
//                fileReader.readAsDataURL(c)
//            } else {
//                d(null)
//            }
//        };
//        this.addNode = function (a, b, c) {
//            if (a && b) {
//                b.css('display', 'none').appendTo(a).fadeIn(function () {
//                    if (typeof c === func) {
//                        try {
//                            c()
//                        } catch (e) {
//                            b.stop();
//                            throw e;
//                        }
//                    }
//                })
//            } else if (typeof c === func) {
//                c()
//            }
//        };
//        this.removeNode = function (a, b) {
//            if (a) {
//                a.fadeOut(function () {
//                    a.remove();
//                    if (typeof b === func) {
//                        try {
//                            b()
//                        } catch (e) {
//                            a.stop();
//                            throw e;
//                        }
//                    }
//                })
//            } else if (typeof b === func) {
//                b()
//            }
//        };
//        this.replaceNode = function (a, b, c) {
//            if (a && b) {
//                a.fadeOut(function () {
//                    b.css('display', 'none');
//                    a.replaceWith(b);
//                    b.fadeIn(function () {
//                        if (typeof c === func) {
//                            try {
//                                c()
//                            } catch (e) {
//                                a.stop();
//                                b.stop();
//                                throw e;
//                            }
//                        }
//                    })
//                })
//            } else if (typeof c === func) {
//                c()
//            }
//        };
//        this.resetProgressBarAll = function () {
//            if (m.progressbarAll) {
//                m.progressbarAll.progressbar('value', 0)
//            }
//        };
//        this.hideProgressBarAll = function (a) {
//            if (m.progressbarAll && !$(getUploadTable(m)).find(m.progressSelector + ':visible:first').length) {
//                m.progressbarAll.fadeOut(a)
//            } else if (typeof a === func) {
//                a()
//            }
//        };
//        this.onAbort = function (a, b, c, d, e) {
//            e.removeNode(e.uploadRow, e.hideProgressBarAll)
//        };
//        this.cancelUpload = function (a, b, c, d, e) {
//            var f = d.readyState;
//            d.abort();
//            if (typeof f !== 'number' || f < 2) {
//                e.onAbort(a, b, c, d, e)
//            }
//        };
//        this.initProgressBar = function (c, d) {
//            if (!c || !c.length) {
//                return null
//            }
//            if (typeof c.progressbar === func) {
//                return c.progressbar({
//                    value: d
//                })
//            } else {
//                c.addClass('progressbar').append($('<div/>').css('width', d + '%')).progressbar = function (a, b) {
//                    return this.each(function () {
//                        if (a === 'destroy') {
//                            $(this).removeClass('progressbar').empty()
//                        } else {
//                            $(this).children().css('width', b + '%')
//                        }
//                    })
//                };
//                return c
//            }
//        };
//        this.destroyProgressBar = function (a) {
//            if (!a || !a.length) {
//                return null
//            }
//            return a.progressbar('destroy')
//        };
//        this.initUploadProgress = function (a, b) {
//            if (!a.upload && b.progressbar) {
//                b.progressbar.progressbar('value', 100)
//            }
//        };
//        this.initUploadProgressAll = function () {
//            if (m.progressbarAll && m.progressbarAll.is(':hidden')) {
//                m.progressbarAll.fadeIn()
//            }
//        };
//        this.onSend = function (a, b, c, d, e) {
//            e.initUploadProgress(d, e)
//        };
//        this.onProgress = function (a, b, c, d, e) {
//            if (e.progressbar && a.lengthComputable) {
//                e.progressbar.progressbar('value', parseInt(a.loaded / a.total * 100, 10))
//            }
//        };
//        this.onProgressAll = function (a, b) {
//            if (m.progressbarAll && a.lengthComputable) {
//                m.progressbarAll.progressbar('value', parseInt(a.loaded / a.total * 100, 10))
//            }
//        };
//        this.onLoadAll = function (a) {
//            multiLoader.complete()
//        };
//        this.initProgressBarAll = function () {
//            if (!m.progressbarAll) {
//                m.progressbarAll = m.initProgressBar((typeof m.progressAllNode === func ? m.progressAllNode(m) : m.progressAllNode), 0)
//            }
//        };
//        this.destroyProgressBarAll = function () {
//            m.destroyProgressBar(m.progressbarAll)
//        };
//        this.initUploadRow = function (c, d, f, g, h) {
//            var i = h.uploadRow = (typeof h.buildUploadRow === func ? h.buildUploadRow(d, f, h) : null);
//            if (i) {
//                h.progressbar = h.initProgressBar(i.find(h.progressSelector), 0);
//                i.find(h.cancelSelector).click(function (e) {
//                    h.cancelUpload(e, d, f, g, h);
//                    e.preventDefault()
//                });
//                i.find(h.previewSelector).each(function () {
//                    var b = $(this),
//                        file = d[f];
//                    if (file) {
//                        setTimeout(function () {
//                            h.loadImage(file, function (a) {
//                                h.addNode(b, $(a))
//                            }, h.previewMaxWidth, h.previewMaxHeight, h.imageTypes, !h.previewAsCanvas)
//                        }, h.previewLoadDelay)
//                    }
//                })
//            }
//        };
//        this.initUpload = function (a, b, c, d, e, f) {
//            e.initUploadRow(a, b, c, d, e);
//            e.addNode(getUploadTable(e), e.uploadRow, function () {
//                if (typeof e.beforeSend === func) {
//                    e.beforeSend(a, b, c, d, e, f)
//                } else {
//                    f()
//                }
//            });
//            e.initUploadProgressAll()
//        };
//        this.parseResponse = function (a) {
//            if (typeof a.responseText !== n) {
//                return $.parseJSON(a.responseText)
//            } else {
//                return $.parseJSON(a.contents().text())
//            }
//        };
//        this.initDownloadRow = function (a, b, c, d, f) {
//            var g, downloadRow;
//            try {
//                g = f.response = f.parseResponse(d);
//                downloadRow = f.downloadRow = (typeof f.buildDownloadRow === func ? f.buildDownloadRow(g, f) : null)
//            } catch (e) {
//                if (typeof f.onError === func) {
//                    f.originalEvent = a;
//                    f.onError(e, b, c, d, f)
//                } else {
//                    throw e;
//                }
//            }
//        };
//        this.onLoad = function (a, b, c, d, e) {
//            var f = getUploadTable(e),
//                downloadTable = getDownloadTable(e),
//                callBack = function () {
//                    if (typeof e.onComplete === func) {
//                        e.onComplete(a, b, c, d, e)
//                    }
//                    multiLoader.complete()
//                };
//            multiLoader.push(Array.prototype.slice.call(arguments, 1));
//            e.initDownloadRow(a, b, c, d, e);
//            if (f && (!downloadTable || f.get(0) === downloadTable.get(0))) {
//                e.replaceNode(e.uploadRow, e.downloadRow, callBack)
//            } else {
//                e.removeNode(e.uploadRow, function () {
//                    e.addNode(downloadTable, e.downloadRow, callBack)
//                })
//            }
//        };
//        this.dropZoneEnlarge = function () {
//            if (!isDropZoneEnlarged) {
//                if (typeof m.dropZone.switchClass === func) {
//                    m.dropZone.switchClass(m.cssClassSmall, m.cssClassLarge)
//                } else {
//                    m.dropZone.addClass(m.cssClassLarge);
//                    m.dropZone.removeClass(m.cssClassSmall)
//                }
//                isDropZoneEnlarged = true
//            }
//        };
//        this.dropZoneReduce = function () {
//            if (typeof m.dropZone.switchClass === func) {
//                m.dropZone.switchClass(m.cssClassLarge, m.cssClassSmall)
//            } else {
//                m.dropZone.addClass(m.cssClassSmall);
//                m.dropZone.removeClass(m.cssClassLarge)
//            }
//            isDropZoneEnlarged = false
//        };
//        this.onDocumentDragEnter = function (a) {
//            m.dropZoneEnlarge()
//        };
//        this.onDocumentDragOver = function (a) {
//            if (dragOverTimeout) {
//                clearTimeout(dragOverTimeout)
//            }
//            dragOverTimeout = setTimeout(function () {
//                m.dropZoneReduce()
//            }, 200)
//        };
//        this.onDragEnter = this.onDragLeave = function (a) {
//            m.dropZone.toggleClass(m.cssClassHighlight)
//        };
//        this.onDrop = function (a) {
//            if (dragOverTimeout) {
//                clearTimeout(dragOverTimeout)
//            }
//            if (m.dropEffect && typeof m.dropZone.effect === func) {
//                m.dropZone.effect(m.dropEffect, function () {
//                    m.dropZone.removeClass(m.cssClassHighlight);
//                    m.dropZoneReduce()
//                })
//            } else {
//                m.dropZone.removeClass(m.cssClassHighlight);
//                m.dropZoneReduce()
//            }
//        };
//        this.init = function () {
//            m.initProgressBarAll()
//        };
//        this.destroy = function () {
//            m.destroyProgressBarAll()
//        };
//        $.extend(this, l)
//    };
//    methods = {
//        init: function (a) {
//            return this.each(function () {
//                $(this).fileUpload(new UploadHandler($(this), a)).fileUploadUI('option', 'init', undefined, a.namespace)()
//            })
//        },
//        option: function (a, b, c) {
//            if (!a || (typeof a === 'string' && typeof b === n)) {
//                return $(this).fileUpload('option', a, b, c)
//            }
//            return this.each(function () {
//                $(this).fileUpload('option', a, b, c)
//            })
//        },
//        destroy: function (a) {
//            return this.each(function () {
//                $(this).fileUploadUI('option', 'destroy', undefined, a)();
//                $(this).fileUpload('destroy', a)
//            })
//        },
//        upload: function (a, b) {
//            return this.each(function () {
//                $(this).fileUpload('upload', a, b)
//            })
//        }
//    };
//    $.fn.fileUploadUI = function (a) {
//        if (methods[a]) {
//            return methods[a].apply(this, Array.prototype.slice.call(arguments, 1))
//        } else if (typeof a === 'object' || !a) {
//            return methods.init.apply(this, arguments)
//        } else {
//            $.error('Method "' + a + '" does not exist on jQuery.fileUploadUI')
//        }
//    }
//}(jQuery));