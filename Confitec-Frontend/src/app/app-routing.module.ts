import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './components/user/user-list/user-list.component';
import { UserFormComponent } from './components/user/user-form/user-form.component';

const routes: Routes = [
  { path: '',   redirectTo: '/users', pathMatch: 'full' },
  { path: 'users',        component: UserListComponent },
  { path: 'user',        component: UserFormComponent  },
  { path: 'user/:id',        component: UserFormComponent  },
  { path: '**', component: UserListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
