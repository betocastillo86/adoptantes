import { BaseModel } from "./base.model";

export class FileModel extends BaseModel
{
    fileName:string;
    mimeType:string;
    name:string;
    thumbnail:string;
}