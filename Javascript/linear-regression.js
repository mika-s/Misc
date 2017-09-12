/**
* Calculate the trend paramenters alpha and beta with linear regression.
* The equation is based on ordinary least squares.
* @param {array} arrayX - Array of X values.
* @param {array} arrayY - Array of Y values.
* @returns {object} object containing alpha and beta
*/
export function calculateTrend (arrayX, arrayY) {
  let sumX = sumOfArray(arrayX)
  let sumY = sumOfArray(arrayY)
  let n = arrayX.length

  let sumElementwiseXmultipliedY = 0
  for (let i = 0; i < n; i++) sumElementwiseXmultipliedY += arrayX[i] * arrayY[i]

  let arrayElementwiseXmultipliedX = []
  arrayX.forEach(function (x) { arrayElementwiseXmultipliedX.push(x * x) })
  let sumElementwiseXmultipliedX = sumOfArray(arrayElementwiseXmultipliedX)

  let betaDividend = n * sumElementwiseXmultipliedY - sumX * sumY
  let betaDivisor = n * sumElementwiseXmultipliedX - sumX * sumX
  if (betaDivisor === 0) throw new Error('Division by zero (divisor in beta).')
  let beta = betaDividend / betaDivisor

  let alphaDividend = sumY - beta * sumX
  let alphaDivisor = n
  if (alphaDivisor === 0) throw new Error('Division by zero (divisor in alpha).')
  let alpha = alphaDividend / alphaDivisor

  return { alpha: alpha, beta: beta }
}

/**
* Make a linear trendline based on an object containing alpha and beta.
* @param {array} arrayX - Array of X values.
* @param {object} trend - Object containing alpha and beta.
* @returns {array} the trendline as an array.
*/
export function makeTrendline (arrayX, trend) {
  let trendline = []
  arrayX.forEach(function (x) { trendline.push(trend.alpha + trend.beta * x) })

  return trendline
}

/**
* Calculate the sum of all the elements in an array.
* @param {array} array - The array to calculate the sum of.
* @returns {number} the sum of all the elements in the array.
*/
function sumOfArray (array) {
  return array.reduce(function (a, b) { return a + b }, 0)
}
