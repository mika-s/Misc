/**
* Sort an array by field in ascending order.
* @param {array} array       - The array to sort.
* @param {primitive} field   - The field to sort by.
* @returns {array} the sorted array.
*/
export function sortBy (array, field) {
  array.sort(function (a, b) {
    if (a[field] < b[field]) {
      return -1
    } else if (a[field] > b[field]) {
      return 1
    } else {
      return 0
    }
  })

  return array
}