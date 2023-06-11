export class User{
    constructor(
        public email:string,
        public password:string,
        public id:number,
        public token:string,
        public role:string,
        public expirationTime:any,
        public authorizedUser:object
        
    ) {}

    // get getToken(){
    //     if(!this._tokenExpirationDate || new Date() > this._tokenExpirationDate){
    //     return null;
    //     }
    //     return this.token;
    // }
};