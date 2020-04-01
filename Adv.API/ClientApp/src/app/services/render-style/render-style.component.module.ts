import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common"
import { RenderStyleComponent } from './render-style.component';
@NgModule({
    imports:[
        CommonModule
    ],
    declarations:[
        RenderStyleComponent
    ],
    exports:[
        RenderStyleComponent
    ]
})
export class RenderStyleModule{
    
}