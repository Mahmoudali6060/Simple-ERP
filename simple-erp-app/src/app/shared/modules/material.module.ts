import { NgModule } from '@angular/core';
import { MatButtonModule, MatDialogModule } from '@angular/material';
import {MatRadioModule} from '@angular/material/radio';

@NgModule({
    imports: [
        MatButtonModule, MatDialogModule,MatRadioModule
    ],
    exports: [
        MatButtonModule, MatDialogModule,MatRadioModule
    ]
})
export class MaterialModule { }