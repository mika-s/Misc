/**
* Get a random color string on the form "rgba(123,25,222,0.7)", 
* representing a color in rgba. R, G and B are random.
* @param {Number} alpha        - Alpha, between 0 and 1.
* @returns {string} an rgba string with random R, G and B.
*/
export function randomRgbaString (alpha) {
  let r = Math.floor(Math.random() * 255)
  let g = Math.floor(Math.random() * 255)
  let b = Math.floor(Math.random() * 255)
  let a = alpha
  return `rgba(${r},${g},${b},${a})`
}

/**
* Get a somewhat-random string on the form "hsla(120,90%,60%,0.7)", 
* representing a color in hsla. The hue is random.
* @param {Number} saturation   - Saturation in percent.
* @param {Number} lightness    - Lightness in percent.
* @param {Number} alpha        - Alpha, between 0 and 1.
* @returns {string} an hsla string with random hue.
*/
export function randomHslaString (saturation, lightness, alpha) {
  let hue = Math.floor(Math.random() * 360)
  return `hsla(${hue},${saturation}%,${lightness}%,${alpha})`
}

/**
* Get an array of somewhat-random strings on the form "hsla(120,90%,60%,0.7)", 
* representing a color in hsla. The hue of the colors are spread over the amount
* of wanted colors in the hue spectrum 0 -> 360 degrees.
* @param {Number} amount       - Number of color strings in the array.
* @param {Number} saturation   - Saturation in percent.
* @param {Number} lightness    - Lightness in percent.
* @param {Number} alpha        - Alpha, between 0 and 1.
* @returns {string} an array of hsla string with random hue.
*/
export function generateHslaColors (saturation, lightness, alpha, amount) {
  let colors = []
  let huedelta = 360 / amount

  for (let i = 0; i < amount; i++) {
    let hue = i * huedelta
    colors.push(`hsla(${hue},${saturation}%,${lightness}%,${alpha})`)
  }

  return colors
}
