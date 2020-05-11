import { FormGroup } from '@angular/forms';
import { Service, CheckNicknameNotTakenQuery } from '../api/api.client.generated';

export function NicknameNotTaken(service: Service, studentId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["nickname"];

        let checkNickname = new CheckNicknameNotTakenQuery();
        checkNickname.nickname = control.value;
        checkNickname.studentId = studentId;

        service.checkNicknameNotTaken(checkNickname)
        .subscribe(result => {
          var nicknameNotTaken = result;
          if (!nicknameNotTaken.result){
              control.setErrors({ nicknameTaken: true });
          }
        });
    }

}