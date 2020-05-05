import { StudentService } from '../shared/student.service';
import { FormGroup } from '@angular/forms';

export function NicknameNotTaken(service: StudentService, studentId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["nickname"];

        service.nicknameNotTaken(control.value, studentId)
        .toPromise()
        .then(res => {
          var nicknameNotTaken = res as Boolean;
          if (!nicknameNotTaken){
              control.setErrors({ nicknameTaken: true });
          }
        });
    }

}