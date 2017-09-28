/**
* Truncate to a given number of decimals.
* @param {Number} number   - The number to truncate.
* @param {Number} decimals - Number of decimals.
* @returns {Number} the value of the given number, truncated to given number of decimals.
*/
export function truncToDecimal (number, decimals) {
  return Math.trunc(number * Math.pow(10, decimals)) / Math.pow(10, decimals)
}

/**
* Round to neareast number with a given number of decimals.
* @param {Number} number   - The number to round.
* @param {Number} decimals - Number of decimals.
* @returns {Number} the value of the given number, rounded to given number of decimals.
*/
export function roundToDecimal (number, decimals) {
  return Math.round(number * Math.pow(10, decimals)) / Math.pow(10, decimals)
}
