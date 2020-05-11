import { StudentService } from '../shared/student.service';
import { FormGroup } from '@angular/forms';
import { CheckNickname } from '../shared/checkNickname.model';
import { NicknameNotTakenVm } from '../shared/nicknameNotTakenVm.model';

export function NicknameNotTaken(service: StudentService, studentId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["nickname"];

        let checkNickname = new CheckNickname();
        checkNickname.Nickname = control.value;
        checkNickname.StudentId = studentId;

        service.nicknameNotTaken(checkNickname)
        .toPromise()
        .then(res => {
          var nicknameNotTaken = res as NicknameNotTakenVm;
          if (!nicknameNotTaken.Result){
              control.setErrors({ nicknameTaken: true });
          }
        });
    }

}