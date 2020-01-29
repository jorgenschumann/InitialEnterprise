export class ArrayUtils {

 static pushToArray(array, object) {
    const index = array.findIndex((e) => e.id === object.id);
    if (index === -1) {
      array.push(object);
    } else {
      array[index] = object; }
  }

  static removeFromArray(array, object) {
    const index = array.findIndex((e) => e.id === object.id);
    if (index > -1) {
      array.splice(index, 1);
    }
  }
}
