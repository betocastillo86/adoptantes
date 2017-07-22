import { Directive, ElementRef, EventEmitter, Output } from '@angular/core';
import { AppSettings } from "../models/configuration.model";
import { FileService } from "../services/file.service";
import { FileModel } from "../models/file.model";

@Directive({
  selector: '[adoUploadFile]',
  outputs: ['onCompleted', 'onError', 'onProgress'],
  inputs: ['defaultName', 'validExtensions']
})
export class UploadFileDirective {

  @Output() onCompleted = new EventEmitter<FileModel>();
  onError = new EventEmitter();
  onProgress = new EventEmitter();

  defaultName:string;
  validExtensions:string;
  
  iFileSent:number;

  constructor(private el:ElementRef, private fileService:FileService) {
      
      el.nativeElement.onchange = () => {
        this.fileSelected();
      };
  }

  private fileSelected()
  {
      let fileUpload = this.el.nativeElement;
      let isMultiple = fileUpload.attributes.multiple !== undefined;

      let errorSize = false;
      let errorExtensions = false;

      var validExtensionsRegex = this.validExtensions ? new RegExp(this.validExtensions, 'i') : null;


      for (let i = 0; i < fileUpload.files.length; i++) {
            if (fileUpload.files[i].size > AppSettings.Security_MaxRequestFileUploadMB * 1024 * 1024) {
                errorSize = true;
            }
            else if (validExtensionsRegex && !validExtensionsRegex.test(fileUpload.files[i].name)) {
                errorExtensions = true;
            }
            else
            {
                this.postFileToServer(fileUpload.files[i]);
            }
      }

      if (errorSize) {
          var message = '';
          if (fileUpload.files.length == 1) {
              message = 'El archivo no puede exceder las ' + AppSettings.Security_MaxRequestFileUploadMB + 'MB. Subir archivos de menor peso.';
          }
          else if (this.iFileSent == 0) {
              message = 'Los archivos no pueden exceder las ' + AppSettings.Security_MaxRequestFileUploadMB + 'MB. Subir archivos de menor peso.';
          }
          else {
              message = 'Hay archivos que exceden las ' + AppSettings.Security_MaxRequestFileUploadMB + 'MB. Subir archivos de menor peso.';
          }
          
          alert(message);
          
          fileUpload.val(null);
      }
      else if (errorExtensions) {
          var message = '';
          if (fileUpload.files.length == 1) {
              message = 'El archivo no tiene una extension válida';
          }
          else if (this.iFileSent == 0) {
              message = 'Los archivos no tienen extensiones válidas.';
          }
          else {
              message = 'Hay archivos no tienen extensiones válidas.';
          }

          alert(message);
          
          fileUpload.val(null);
      }
  }

  private postFileToServer(file:any)
  {
    this.fileService.post(file, this.defaultName)
    .subscribe(data => {
      var fileModel = data as FileModel;
      this.postCompleted(fileModel);
      this.iFileSent++;
    },
      err => { this.postError(err) });
  }

  private postCompleted(file:FileModel)
  {
      this.onCompleted.emit(file);
  }

  private postError(err:any)
  {
     this.onError.emit(err);
  }

}
