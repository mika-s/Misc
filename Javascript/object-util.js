/**
* Check whether the object is empty or not.
* @param {object} objectToCheck - The object to check for emptyness.
* @returns {boolean} true if empty, false otherwise.
*/
export function objectIsEmpty (objectToCheck) {
  return Object.getOwnPropertyNames(objectToCheck).length === 0
}

/**
* Check whether the variable is in the array or not.
* @param {primitive} variable - The variable to check whether is in the array.
* @param {array} array        - The array to check in.
* @returns {boolean} true if variable is in array, false otherwise.
*/
export function variableIsInArray (variable, array) {
  return array.indexOf(variable) !== -1
}
