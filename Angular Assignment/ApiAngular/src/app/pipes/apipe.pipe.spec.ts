
import { ApipePipe } from './apipe.pipe';

describe('ApipePipe', () => {
  it('create an instance', () => {
    const pipe = new ApipePipe();
    expect(pipe).toBeTruthy();
  });
  it('should be display if number is passed',()=>{
    const s=new ApipePipe();
    expect(s.transform(50000)).toEqual('my salary is 50000');
  })
});
