export class Base64 {
  constructor() {}

  public static base64ToArrayBuffer(base64: string): any[] {
    const binaryString = atob(base64);
    const length = binaryString.length;
    const bytes = new Uint8Array(length);
    for (let i = 0; i < length; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }
    return [bytes.buffer];
  }
}
