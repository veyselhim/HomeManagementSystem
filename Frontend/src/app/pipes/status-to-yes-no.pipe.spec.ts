import { StatusToYesNoPipe } from './status-to-yes-no.pipe';

describe('StatusToYesNoPipe', () => {
  it('create an instance', () => {
    const pipe = new StatusToYesNoPipe();
    expect(pipe).toBeTruthy();
  });
});
