declare module google {
    export interface loadInterface {
        (...args: any[]): any;
    }

    export var load: loadInterface;
}

