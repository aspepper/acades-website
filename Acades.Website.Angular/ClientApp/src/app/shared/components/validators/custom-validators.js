"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var moment = require("moment");
var CustomValidators = /** @class */ (function () {
    function CustomValidators() {
    }
    CustomValidators.dateMinimum = function (date) {
        return function (control) {
            var FORMAT_DATE = "DD/MM/YYYY";
            if (!control.value) {
                return null;
            }
            var controlDate = moment(control.value, FORMAT_DATE);
            if (!controlDate.isValid()) {
                return {
                    'date-minimum': {
                        'date-minimum': 'invalid date',
                        'actuel': control.value
                    }
                };
            }
            var validationDate = moment(date, FORMAT_DATE);
            return controlDate.isAfter(validationDate) ? null : {
                'date-minimum': {
                    'date-minimum': validationDate.format(FORMAT_DATE),
                    'actuel': controlDate.format(FORMAT_DATE)
                }
            };
        };
    };
    return CustomValidators;
}());
exports.CustomValidators = CustomValidators;
//# sourceMappingURL=custom-validators.js.map