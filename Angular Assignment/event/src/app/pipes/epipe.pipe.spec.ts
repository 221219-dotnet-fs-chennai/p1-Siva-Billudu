import { EpipePipe } from './epipe.pipe';

describe('EpipePipe', () => {
  it('create an instance', () => {
    const pipe = new EpipePipe();
    expect(pipe).toBeTruthy();
  });
  it('should be display if number is passed',()=>{  
       const s=new EpipePipe();    
        expect(s.transform(50000)).toEqual('my salary is 50000');  
       })

});
