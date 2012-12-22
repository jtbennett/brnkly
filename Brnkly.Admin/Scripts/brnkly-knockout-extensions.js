/* Bootstrap checkbox binding */
ko.bindingHandlers.checkbox = {
    init: function (element, valueAccessor, allBindings, data, context) {
        var $element, observable;
        observable = valueAccessor();
        if (!ko.isWriteableObservable(observable)) {
            throw "You must pass an observable or writeable computed";
        }
        $element = $(element);
        $element.on("click", function () {
            observable(!observable());
        });
        ko.computed({
            disposeWhenNodeIsRemoved: element,
            read: function () {
                $element.toggleClass("active", observable());
            }
        });
    }
};

/* Bootstrap radio button binding */
ko.bindingHandlers.radio = {
    init: function (element, valueAccessor, allBindings, data, context) {
        var $buttons, $element, observable;
        observable = valueAccessor();
        if (!ko.isWriteableObservable(observable)) {
            throw "You must pass an observable or writeable computed";
        }
        $element = $(element);
        if ($element.hasClass("btn")) {
            $buttons = $element;
        } else {
            $buttons = $(".btn", $element);
        }
        elementBindings = allBindings();
        $buttons.each(function () {
            var $btn, btn, radioValue;
            btn = this;
            $btn = $(btn);
            radioValue = elementBindings.radioValue || $btn.attr("data-value") || $btn.attr("value") || $btn.text();
            $btn.on("click", function () {
                observable(ko.utils.unwrapObservable(radioValue));
            });
            return ko.computed({
                disposeWhenNodeIsRemoved: btn,
                read: function () {
                    $btn.toggleClass("active", observable() === ko.utils.unwrapObservable(radioValue));
                }
            });
        });
    }
};

/* Dirty flag */
/* http://www.knockmeout.net/2011/05/creating-smart-dirty-flag-in-knockoutjs.html */
ko.dirtyFlag = function (root, isInitiallyDirty) {
    var result = function () { },
        _initialState = ko.observable(ko.toJSON(root)),
        _isInitiallyDirty = ko.observable(isInitiallyDirty);

    result.isDirty = ko.dependentObservable(function () {
        return _isInitiallyDirty() || _initialState() !== ko.toJSON(root);
    });

    result.reset = function () {
        _initialState(ko.toJSON(root));
        _isInitiallyDirty(false);
    };

    return result;
};
